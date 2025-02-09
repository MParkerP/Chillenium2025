using UnityEngine;

public class RaycastClickAndDrag : MonoBehaviour
{
    int releaseVelocity;
    private Vector3 offset;

    private Camera mainCamera;
    private bool holding;
    private Collider2D colliderHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            colliderHit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (colliderHit != null && colliderHit.gameObject.layer == 6)
            {
                holding = true;
                //rb.linearVelocity = new Vector2(mousePosition.x - t.position.x, mousePosition.y - t.position.y) * 45;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            holding = false;
        }

        holdingObject();
    }


    void holdingObject()
    {


        if (holding)
        {
            Transform t = colliderHit.transform;
            Rigidbody2D rb = colliderHit.attachedRigidbody;
            Vector3 mousePosition = GetMouseWorldPosition();
            mousePosition.z = 0;
            rb.transform.position = mousePosition;
        }
    }
    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0f;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}



