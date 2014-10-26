using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    //parametre na urcenie orientacie nepriatela
    public BoxCollider2D colider;
    bool isFacingRight = true;

    //parametry na urcenie akceleracie a rychlosti pohybu nepriatelov
    public float gravity = 20;
    public float speed = 8;
    public float acceleration = 30;
    public float targetSpeed;

    //privatne premenne na chod nepriatela
    private float currentSpeed;
    private Vector2 position = new Vector2(0, 0); //pozicia nepriatela
    public bool IsHeroOnDesk { set; private get; } //premenna ci je hrdina na doske
    
    //konstruktor
    void Start()
    {
        IsHeroOnDesk = false;
    }

    void Update()
    {
        //je hrdina na doske - aktivacia nepriatelov
        if (IsHeroOnDesk)
        {
            //nastavenie rychlosti
            currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);
            //kontrola ci nepriatel sa neotocil
            int check = 0;
            //zistuje na ktorej strane je hrdina - ci je hrdina nalavo
            if (position.x<this.rigidbody2D.position.x)
            {
                //pohyb
                transform.position -= Vector3.right * currentSpeed * Time.deltaTime;
                //otocenie ak je otoceny na zlu stranu
                if (!isFacingRight)
                {
                    this.Flip();
                }

            }
            else
            {
                //hrdina je napravo
                check++;
            }

            //zistuje ci je hrdina napravo
            if (position.x > this.rigidbody2D.position.x)
            {
                //pohyb
                transform.position += Vector3.right * currentSpeed * Time.deltaTime;
                //otocenie ak je na zlu stranu otoceny
                if (isFacingRight)
                {
                    this.Flip();
                }
            }
            else
            {
                //hrdina je nalavo
                check++;
            }
            //hrdina bol nalavo aj napravo pocas jedeho updatu - zastav nepriatela
            if (check == 2)
            {
                currentSpeed = 0;
            }
        }
        //hrdina nieje na ploche - nulova rychlost
        else
        {
            currentSpeed = 0;
        } 
    }
    
    //sposob vypoctu rychlosti nepriatela
    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }

    //otocenie
    void Flip()
    { 
        isFacingRight = (!isFacingRight);
        Vector3 theScale = transform.localScale; 
        theScale.x *= -1;						
        transform.localScale = theScale;		
    }
    //metoda na urcenie pozicie hrdinu
    public void setHeroPosition(Vector2 position)
    {
        this.position = position;
    }
    //metoda na detekovanie hrdinu - moze nan zautocit
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("hrdina"))
        {
            Destroy(collision.gameObject);
        }

    }
    
}
