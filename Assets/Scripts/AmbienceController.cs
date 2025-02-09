using System.Collections;
using UnityEngine;

public class AmbienceController : MonoBehaviour
{
    [SerializeField] private GameObject tarmacImage;
    [SerializeField] private float tarmacTargetY;
    [SerializeField] private float tarmacIncrement;

    private AudioSource audioSource;
    [SerializeField] private AudioClip takeoff;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator planeTakeOff()
    {
        audioSource.PlayOneShot(takeoff);
        while (tarmacImage.transform.position.y > tarmacTargetY)
        {
            tarmacImage.transform.position = tarmacImage.transform.position + new Vector3(0, -tarmacIncrement, 0);
        }
        yield return new WaitForSeconds(.01f);
    }
}
