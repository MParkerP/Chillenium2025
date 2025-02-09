using UnityEngine;

public class KnockOffScript : MonoBehaviour
{
    Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        body.gravityScale = 1;
    }
}
