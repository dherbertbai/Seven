using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public float Speed = 5;
    
    public float JumpPower = 17;
    public float Gravity = 3;
    public bool OnGround = false;
    public bool Bounce;
    public bool Pause;
    
    public bool FacingLeft = false;
    public Animator ANI;

    public GameObject Net;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Pause = false;
        rb.gravityScale = Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.linearVelocity;
        
        if (Input.GetKey(KeyCode.D))
        { 
            //If I hit right, move right
            vel.x = Speed;
            //If I hit right, mark that I'm not facing left
            FacingLeft = false;
            ANI.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.A))
        { 
            //If I hit left, move right
            vel.x = -Speed;
            //If I hit left, mark that I'm facing left
            FacingLeft = true;
            ANI.SetBool("Walking", true);
        }
        else
        {  //If I hit neither, come to a stop
            vel.x = 0;
            ANI.SetBool("Walking", false);
        }

        //If I hit Z and can jump, jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Bounce == false && CanJump())
            {
                vel.y = JumpPower;
            }
            else if(Bounce == true)
            {
                vel.y = JumpPower + 5;
            }
        }

        if (Bounce == true && CanJump())
        {
            vel.y = JumpPower/2;
        }
        rb.linearVelocity = vel;
        sr.flipX = FacingLeft;
        
    }
    
    private bool CanJump()
    {
        return OnGround;
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnGround = true;
        
        if (other.gameObject.CompareTag("Bouncy"))
        {
            Bounce = true;
        }
        else
        {
            Bounce = false;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        OnGround = true;
        if (other.gameObject.CompareTag("Task"))
        {
            if (Input.GetKeyDown(KeyCode.E) & Pause == false)
            {
                Pause = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) & Pause == true)
            {
                Pause = false;
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Task"))
        {
            if (Input.GetKeyDown(KeyCode.E) & Pause == false)
            {
                Pause = true;
            }
            if (Input.GetKeyDown(KeyCode.E) & Pause == true)
            {
                Pause = false;
            }
            
        }
        throw new NotImplementedException();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //If I stop touching something solid, mark me as not being on the ground
        OnGround = false;
    }
}
