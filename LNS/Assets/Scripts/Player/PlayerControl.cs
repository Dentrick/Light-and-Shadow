using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public Rigidbody2D self; //own rigidbody
    public SpriteRenderer sprite; //own sprite

    public Sprite normalSprite; //normal sprite
    public Sprite jumpSprite; //jumping sprite

    public float grav = -.135f; //gravity in units/second^2
    public float mass = 1; //regular multiplier to forces
    public float grabMass = .1f; //walljump multiplier to forces
    public float currMass = 1; //current multiplier to forces
    public float jumpForce = 4f; //jump accel due to force in units/second^2 (MUST BE LARGER ABS VAL THAN grav)
    public float movespeed = 1.1f; //movement speed of player 

    public float velocity = 0; //current velocity
    public bool onFloor = true; //bool for floor collision (public for referencing)
    public bool wallJumpReset = false; //allow walljump only once, resetting on trigger exit
    public bool isDead = false; //check if dead
    public int BallsCollected = 0; //# of balls collected

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
        JumpSwapSprite();
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
        else if (!onFloor)
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

    //jump method
    void Jump()
    {
        //if jump press and touching ground
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) 
        {
            if (onFloor)
            {
                ApplyForce(jumpForce); //units/second^2 upwards
                onFloor = false;
                wallJumpReset = true; //double jump
            }
            else if (wallJumpReset)
            {
                velocity = 0;
                ApplyForce(jumpForce); //units/second^2 upwards
                wallJumpReset = false;
            }
        }
    }

    //sprite swap on jump
    void JumpSwapSprite()
    {
        if (onFloor)
        {
            sprite.sprite = normalSprite;
        }
        else
        {
            sprite.sprite = jumpSprite;
        }
    }

    //apply a force (all forces are vertical)
    void ApplyForce(float force)
    {
        velocity += (mass * force * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("spike") ^ col.gameObject.name.Contains("laser"))
            isDead = true;
        else if (col.gameObject.name.Contains("Finish"))
        {
            BallsCollected++;
            onFloor = false; //wonky physics on win sometimes
            Destroy(col.gameObject);
        }
    }
}
