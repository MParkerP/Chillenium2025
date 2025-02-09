using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if(transform.position.y < -0.8f|| transform.position.y > 6f|| transform.position.x < -9.2|| transform.position.x > 9.2f )
        {
            Destroy(gameObject);
        }
    }
}