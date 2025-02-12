using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    [SerializeField] float leftBound = -9.2f;
    [SerializeField] float rightBound = 9.2f;
    [SerializeField] float bottomBound = -0.8f;
    [SerializeField] float topBound = 6f;
   
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if(transform.position.y < bottomBound|| transform.position.y > topBound|| transform.position.x < leftBound|| transform.position.x > rightBound )
        {
            Destroy(gameObject);
        }
    }
}