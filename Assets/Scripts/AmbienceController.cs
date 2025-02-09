using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AmbienceController : MonoBehaviour
{
    [SerializeField] private GameObject tarmacImage;
    [SerializeField] private float tarmacTargetY;
    [SerializeField] private float tarmacIncrement;
    [SerializeField] private float tarmacScaler;
    private bool isTakingOff = false;

    private AudioSource audioSource;
    [SerializeField] private AudioClip takeoff;
    [SerializeField] private AudioSource brownNoise;

    [SerializeField] private GameObject[] shakyObjects;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(takeoff);
        StartCoroutine(Takeoff());
    }

    IEnumerator Takeoff()
    {
        yield return new WaitForSeconds(3);
        isTakingOff=true;
        yield return new WaitForSeconds(10);
        brownNoise.Play();
    }

    private void FixedUpdate()
    {
        if (isTakingOff && tarmacImage.transform.position.y > tarmacTargetY)
        {
            tarmacImage.transform.position = tarmacImage.transform.position + new Vector3(0, -tarmacIncrement, 0) * tarmacScaler;
            tarmacScaler += 0.025f;
        }
    }
}
