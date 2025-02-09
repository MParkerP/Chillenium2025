using UnityEngine;

public class RaycastClickAndDrag : MonoBehaviour
{
    int releaseVelocity;
    private Vector3 offset;

    private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Collider2D colliderHit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (colliderHit != null && colliderHit.gameObject.layer == 6)
            {
                Transform t = colliderHit.transform;
                Rigidbody2D rb = colliderHit.attachedRigidbody;
                Vector3 mousePosition = GetMouseWorldPosition();
                rb.linearVelocity = new Vector2(mousePosition.x - t.position.x, mousePosition.y - t.position.y) * 45;
            }
        }
    }
    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0f;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}



