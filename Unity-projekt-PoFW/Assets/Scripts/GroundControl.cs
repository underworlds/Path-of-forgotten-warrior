using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//trieda sluzi na urcenia pozicie hrdinu a aktivaciu nepriatelov

public class GroundControl : MonoBehaviour {

    //zoznam nepriatelov na danej plosinke
    public List<Transform> objs = new List<Transform>();

    //zisti ci sa plosiny dotkol alebo nie
    void OnCollisionEnter2D(Collision2D collision)
    {
        //kontroluje kto sa dotkol danej plosiny 
        if (collision.gameObject.tag.Equals("Character"))
        {
            //posle kazdemu nepriatelovy na plosine info ze hrdina je na plosine
            foreach(Transform obj in objs)
            {
                //Debug.Log("jump on");
				if(obj != null){
                obj.GetComponent<EnemyBehaviour>().IsHeroOnDesk = true;
				}

                //Debug.Log(obj.GetComponent<EnemyBehaviour>().IsHeroOnDesk.ToString());
            }
            
            
        }
        
        
    }


    //zistuje poziciu danych objektov
    void OnCollisionStay2D(Collision2D coll)
    {
        //zistuje poziciu hrdinu
        if (coll.gameObject.tag.Equals("Character"))
        {
            //posiela poziciu hrdinu nepriatelom
            foreach (Transform obj in objs)
            {
               // Debug.Log("move to hero");
				if(obj != null){
					obj.GetComponent<EnemyBehaviour>().setHeroPosition(new Vector2(coll.gameObject.rigidbody2D.position.x, coll.gameObject.rigidbody2D.position.y));
				}
                
            }
           
        }
        
        //Destroy(coll.gameObject);
    }

    //zistuje ktore objekty sa uz nedotikaju plosiny
    void OnCollisionExit2D(Collision2D collision)
    {
        //skontroluje ci dany objekt ktory opustil plosinu nebol nahodou hrdina
        if (collision.gameObject.tag.Equals("Character"))
        {
            //uspi vsetkych nepriatelov
            foreach (Transform obj in objs)
            {
				if(obj != null){
				obj.GetComponent<EnemyBehaviour>().IsHeroOnDesk = false;
				}
               // Debug.Log("hero leaves");
            }
        }
       
    }
}
