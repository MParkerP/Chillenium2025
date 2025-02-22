using UnityEngine;

public class DragSnapBack : MonoBehaviour
{
    [SerializeField] private bool showOnSnap = false;
    private bool isDragging;
    private Vector3 offset;
    public Transform snapPoint;
    private Camera mainCamera;
    [SerializeField] private Animator animator;
    private Color color;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        if (snapPoint == null) return;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        if (!showOnSnap)
        {
            color = Color.white;
            color.a = 1;
            sprite.color = color;
        }


    }

    void OnMouseUp()
    {
        if (snapPoint == null) return;
        isDragging = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, 0, 0);
        transform.position = snapPoint.position;
        if (!showOnSnap)
        {
            color.a = 0;
            sprite.color = color;
        }

    }

    void Update()
    {
        if (animator != null)
        {
            animator.SetBool("isEmpty", isDragging);
        }
        if (isDragging && snapPoint != null)
        {
            Vector3 mousePosition = GetMouseWorldPosition() + offset;
            transform.position = mousePosition;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0f;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}