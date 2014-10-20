using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public BoxCollider2D colider;

   // public float speed = 1.0f;
    bool isFacingRight = true;

    public float gravity = 20;
    public float speed = 8;
    public float acceleration = 30;
    public float targetSpeed;

    private float currentSpeed;
    private Vector2 position = new Vector2(0, 0);
    public bool IsHeroOnDesk { set; private get; }

    void Start()
    {
        IsHeroOnDesk = false;
    }

    void Update()
    {
        if (IsHeroOnDesk)
        {
            currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);
            int check = 0;
           // if (Input.GetKey(KeyCode.LeftArrow))
            if (position.x<this.rigidbody2D.position.x)
            {
                transform.position -= Vector3.right * currentSpeed * Time.deltaTime;
                if (!isFacingRight)
                {
                    this.Flip();
                }

            }
            else
            {
                check++;
            }

           // if (Input.GetKey(KeyCode.RightArrow))
            if (position.x > this.rigidbody2D.position.x)
            {
                transform.position += Vector3.right * currentSpeed * Time.deltaTime;
                if (isFacingRight)
                {
                    this.Flip();
                }
            }
            else
            {
                check++;
            }
            if (check == 2)
            {
                currentSpeed = 0;
            }
        }
        else
        {
            currentSpeed = 0;
        } 
    }
   
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

    void Flip()
    { 
        isFacingRight = (!isFacingRight);
        Vector3 theScale = transform.localScale; 
        theScale.x *= -1;						
        transform.localScale = theScale;		
    }

    public void setHeroPosition(Vector2 position)
    {
        this.position = position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("hrdina"))
        {
            Destroy(collision.gameObject);
        }

    }
    
}
