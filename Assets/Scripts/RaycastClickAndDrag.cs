using UnityEngine;

public class RaycastClickAndDrag : MonoBehaviour
{
    int releaseVelocity;
    private Vector3 offset;

    private Camera mainCamera;
    private bool holding;
    private Collider2D colliderHit;
    public LayerMask birdLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            colliderHit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), birdLayer);
            if (colliderHit != null)
            {
                holding = true;
                //rb.linearVelocity = new Vector2(mouse.x - t.position.x, mouse.y - t.position.y) * 45;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            holding = false;
            Transform t = null;
            if (colliderHit != null)
            {
                t = colliderHit.transform;
                Vector3 mouse = GetMouseWorldPosition();
                colliderHit.attachedRigidbody.linearVelocity = new Vector2(mouse.x - t.position.x, mouse.y - t.position.y) * 25;
            }
            // colliderHit.attachedRigidbody.gravityScale = 1;
        }

        holdingObject();
    }


    void holdingObject()
    {
        if (holding)
        { if (colliderHit != null)
            {
                Transform t = colliderHit.transform;
                Rigidbody2D rb = colliderHit.attachedRigidbody;
                Vector3 mousePosition = GetMouseWorldPosition();
                mousePosition.z = 0;
                rb.transform.position = mousePosition;
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



