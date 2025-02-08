using UnityEngine;

public class SnappingDraggable : MonoBehaviour
{
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
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        color = Color.white;
        color.a = 1;
        sprite.color = color;

    }

    void OnMouseUp()
    {
        if (snapPoint == null) return;
        isDragging = false;
        transform.position = snapPoint.position;
        color.a = 0;
        sprite.color = color;
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