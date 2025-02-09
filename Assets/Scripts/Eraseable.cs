using UnityEngine;

public class Eraseable : MonoBehaviour
{

    private float currentOpacity;
    private SpriteRenderer sprite;
    public Color color;

    void Start()
    {
        currentOpacity = 1f;
        sprite = GetComponent<SpriteRenderer>();
        color = Color.white;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        currentOpacity -= 0.2f;
        color.a = currentOpacity;
        sprite.color = color;
        if (currentOpacity <= 0)
        {
            Destroy(gameObject);
        }
    }


}
