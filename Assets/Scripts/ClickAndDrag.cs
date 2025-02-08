using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging;
    private Vector3 offset;
    private Rigidbody2D rb;
    private Camera mainCamera;
    private Vector2 releaseVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;
        rb.linearVelocity = Vector2.zero;
        offset = transform.position - GetMouseWorldPosition();
        rb.gravityScale = 0;
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.gravityScale = 1;

        if (releaseVelocity != Vector2.zero)
        {
            rb.linearVelocity = releaseVelocity;
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = GetMouseWorldPosition() + offset;
            rb.MovePosition(mousePosition);
            releaseVelocity = (mousePosition - transform.position) / Time.deltaTime;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0f;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}