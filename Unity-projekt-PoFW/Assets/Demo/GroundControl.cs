using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundControl : MonoBehaviour {

    public List<Transform> objs = new List<Transform>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("hrdina"))
        {
            foreach(Transform obj in objs)
            {
                obj.GetComponent<EnemyBehaviour>().IsHeroOnDesk = true;
            }
           
           // Debug.Log("jump on");
        }
        
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.name.Equals("hrdina"))
        {
            foreach (Transform obj in objs)
            {
                obj.GetComponent<EnemyBehaviour>().setHeroPosition(new Vector2(coll.gameObject.rigidbody2D.position.x, coll.gameObject.rigidbody2D.position.y));
            }
           
        }
        
        //Destroy(coll.gameObject);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("hrdina"))
        {
            foreach (Transform obj in objs)
            {
                obj.GetComponent<EnemyBehaviour>().IsHeroOnDesk = false;
            }
        }
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    }
}
