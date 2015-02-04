
using UnityEngine;
using System.Collections;

public class TrapAI : MonoBehaviour {

    private const float ROTATION_SPEED = 300.0f;

    private float right;
    // Use this for initialization
    void Start()
    {
        right = 1f;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag.Equals("Traps"))
        {
            this.Flip();

        }
    }

    void Update()
    {
        this.rigidbody2D.velocity = new Vector2(right, rigidbody2D.velocity.y);

        transform.Rotate(0, 0, ROTATION_SPEED * right * Time.deltaTime);
    }


    void Flip()
    { //fliping the world
        right *= -1f;
        Vector3 theScale = transform.localScale; //let me get local scale
        theScale.x *= -1;						// flip x axis	
        transform.localScale = theScale;		//get it back to local scale 
    }
}
