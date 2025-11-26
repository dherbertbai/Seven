using UnityEngine;

public class LedgeScript : MonoBehaviour
{
    public GameObject Player;

    public Collider2D HitBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y > transform.position.y + 0.5)
        {
            HitBox.enabled = true;
        }
        else if (Player.transform.position.y < transform.position.y - 0.5)
        {
            HitBox.enabled = false;
        }
    }
}
