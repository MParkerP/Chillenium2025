using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShapeButton : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private SimonSays simon;
    [SerializeField] private Animator animator;
    [SerializeField] private Light2D light;
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

    public void toggleLight()
    {
        light.enabled = !light.enabled;
    }
}