using UnityEngine;

public class ShapeButton : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private SimonSays simon;

    public void OnMouseDown()
    {
        simon.recieveInput(name);
    }
}
