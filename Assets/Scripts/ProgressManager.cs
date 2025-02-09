using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private GameObject progressBar;
    [SerializeField] private float progressBarIncrement;

    private void FixedUpdate()
    {
        progressBar.transform.position = progressBar.transform.position + new Vector3(-progressBarIncrement, 0, 0);
    }

}
