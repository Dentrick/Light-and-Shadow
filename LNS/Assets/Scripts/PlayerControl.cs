using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public Rigidbody2D self; //own rigidbody
    public SpriteRenderer sprite; //own sprite

    public float grav = -.1f; //gravity in units/second^2
    public float mass = 1; //multiplier to forces
    public float jumpForce = 4f; //jump accel due to force in units/second^2 (MUST BE LARGER ABS VAL THAN grav)
    public float movespeed = 1.1f; //movement speed of player 

    [SerializeField] float velocity = 0; //current velocity
    [SerializeField] bool isOnFloor = true; //bool for floor collision

    // Use this for initialization
    void Start()
    {
        movespeed *= Time.deltaTime; //convert movespeed to 
    }
	
	// Update is called once per frame
    // 2D platformer movement with basic gravity
	void Update ()
    {
        Jump();
        ApplyHorzMove();
        ApplyVertMove();
	}

    //up/down movment calculation
    void ApplyVertMove()
    {
        //modify velocity with grav
        ApplyForce(grav);
        if (velocity > 0)
            transform.Translate(new Vector3(0, velocity), Space.World); //translate up according to velocity
        else if (!isOnFloor)
            transform.Translate(new Vector3(0, velocity), Space.World); //translate up or down according to velocity
        else
            velocity = 0;
        
    }

    //left/right movement calculation
    void ApplyHorzMove()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Translate(new Vector3(-movespeed, 0), Space.World); //translate left according to move speed
            sprite.flipX = true;//graphical cheat, flip sprite
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Translate(new Vector3(movespeed, 0), Space.World); //translate right according to move speed
            sprite.flipX = false;//graphical cheat, flip sprite
        }
    }

    //basic jump method
    void Jump()
    {
        //if jump press and touching ground
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isOnFloor) 
        {
            velocity = 0;
            ApplyForce(jumpForce); //10 units/second^2 upwards
        }
    }

    //apply a force (all forces are vertical)
    void ApplyForce(float force)
    {
        velocity += (mass * force * Time.deltaTime);
    }

    //collision check method
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "Floor" || col.gameObject.name == "Block" || col.gameObject.name.Contains("shadow"))
            isOnFloor = true;
    }

    //collision uncheck method
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Floor" || col.gameObject.name == "Block" || col.gameObject.name.Contains("shadow"))
            isOnFloor = false;
    }
}
