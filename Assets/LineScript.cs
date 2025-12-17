using UnityEngine;

public class LineScript : MonoBehaviour
{
    public GameObject bar;
    public GameObject task;
    public NetScript panel;
    public PlayerScript player;
    
    public SpriteRenderer sr;
    public SpriteRenderer sr2;
    public BoxCollider2D box;
    
    public float timer;

    public Rigidbody2D rb;
    Vector2 vel = new Vector2(0,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0f;
    }

    public void StartUp()
    {
        vel.x = bar.transform.position.x - 5;
        vel.y = bar.transform.position.y;
        transform.position = vel;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            vel.x += 5f*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.E))
        {
            //vel.x = bar.transform.position.x - 5;
            //vel.y = bar.transform.position.y;
        }
        transform.position = vel;

        if (timer >= 1f)
        {
            sr.color = Color.white;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pop"))
        {
            Miss();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (other.gameObject.CompareTag("Goal"))
            {
                Hit();
            }
            else if (!other.gameObject.CompareTag("Goal"))
            {
                Miss();
            }
        }
        
    }
    public void Miss()
    {
        vel.x = bar.transform.position.x - 5;
        transform.position = vel;
        timer = 0f;
        sr.color = Color.red;
    }

    public void Hit()
    {
        sr2.color = Color.green;
        box.enabled = false;
        task.SetActive(false);
        //panel.Done();
    }
}
