using UnityEngine;

public class NetScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject task;

    public BoxCollider2D hitbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr.color = Color.yellow;
        hitbox.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Done()
    {
        //task.SetActive(false);
        sr.color = Color.green;
        hitbox.enabled = false;
    }
}
