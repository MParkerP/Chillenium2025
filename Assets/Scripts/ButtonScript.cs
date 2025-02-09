using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator animator;
    Animator signAnimator;
    HappinessScript sign;
    [SerializeField] GameObject HappinessManager;
    [SerializeField] GameObject seatBeltSign;
    private AudioSource audioSource;
    public AudioClip buttonClick;
    public AudioClip fastenSeatbeltSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        signAnimator = seatBeltSign.GetComponent<Animator>();
        sign = HappinessManager.GetComponent<HappinessScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("pressed", false);
            
        }
    }

    private void OnMouseDown()
    {
        
            bool colliderHit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (colliderHit)
            {
                audioSource.PlayOneShot(buttonClick);
                audioSource.PlayOneShot(fastenSeatbeltSound);
                animator.SetBool("pressed",true);
                signAnimator.SetTrigger("toggle");
                sign.toggle();
            }
        
        
    }

}
