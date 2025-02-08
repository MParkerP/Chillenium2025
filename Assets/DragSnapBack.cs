using UnityEngine;

public class SnappingDraggable : MonoBehaviour
{
    private bool isDragging;
    private Vector3 offset;
    public Transform snapPoint;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        if (snapPoint == null) return;
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        if (snapPoint == null) return;
        isDragging = false;
        transform.position = snapPoint.position;
    }

    void Update()
    {
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