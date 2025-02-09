using UnityEngine;

public class Eraseable : MonoBehaviour
{
    private AudioSource audioSource;

    private float currentOpacity;
    private SpriteRenderer sprite;
    public Color color;
    public AudioClip squeak;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentOpacity = 1f;
        sprite = GetComponent<SpriteRenderer>();
        color = Color.white;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Sponge"))
        {
            audioSource.PlayOneShot(squeak);
            currentOpacity -= 0.2f;
            color.a = currentOpacity;
            sprite.color = color;
            if (currentOpacity <= 0)
            {
                Destroy(gameObject);
            }
        }

    }


}
