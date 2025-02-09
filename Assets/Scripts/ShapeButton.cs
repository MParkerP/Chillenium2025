using UnityEngine;

public class ShapeButton : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private SimonSays simon;
    [SerializeField] private Animator animator;

    public void OnMouseDown()
    {
        simon.recieveInput(name);
        lower();
    }

    public void raise()
    {
        if (animator != null)
        {
            animator.SetBool("down", false);
        }
    }
    void lower()
    {
        if (animator != null)
        {
            animator.SetBool("down", true);
        }

    }
}