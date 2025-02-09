using UnityEngine;

public class RotateRandomly : MonoBehaviour
{
    void Start()
    {
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
