using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public float speed = 5;
    public float time;
    
    public float jumpPower = 17;
    public float gravity = 3;
    public bool OnGround = false;
    public bool bounce;
    public bool pause;
    
    public bool facingLeft = false;
    public Animator ani;

    public GameObject skill;
    public LineScript line;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pause = false;
        skill.SetActive(false);
        rb.gravityScale = gravity;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.linearVelocity;
        time += Time.deltaTime;
        
        if (Input.GetKey(KeyCode.D) & pause == false)
        { 
            //If I hit right, move right
            vel.x = speed;
            //If I hit right, mark that I'm not facing left
            facingLeft = false;
            ani.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.A) & pause == false)
        { 
            //If I hit left, move right
            vel.x = -speed;
            //If I hit left, mark that I'm facing left
            facingLeft = true;
            ani.SetBool("Walking", true);
        }
        else
        {  //If I hit neither, come to a stop
            vel.x = 0;
            ani.SetBool("Walking", false);
        }

        //If I hit Z and can jump, jump
        if (Input.GetKeyDown(KeyCode.W) & pause == false)
        {
            if (bounce == false && CanJump())
            {
                vel.y = jumpPower;
            }
            else if(bounce == true)
            {
                vel.y = jumpPower + 5;
            }
        }

        if (bounce == true && CanJump())
        {
            vel.y = jumpPower/2;
        }
        rb.linearVelocity = vel;
        sr.flipX = facingLeft;
        if(!skill.activeSelf)
        {
            pause = false;
        }
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
            bounce = true;
        }
        else
        {
            bounce = false;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        OnGround = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Task"))
        {
            if (Input.GetKey(KeyCode.E) & pause == false & time >= 0.3f)
            {
                time = 0f;
                pause = true;
                skill.SetActive(true);
                line.StartUp();
            }
            else if (Input.GetKey(KeyCode.E) & pause == true & time >= 0.3f)
            {
                time = 0f;
                pause = false;
                skill.SetActive(false);
            }
        }
    }
    
    
    

    private void OnCollisionExit2D(Collision2D other)
    {
        //If I stop touching something solid, mark me as not being on the ground
        OnGround = false;
    }
}
