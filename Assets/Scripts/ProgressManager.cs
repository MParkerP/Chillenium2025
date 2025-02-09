using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private GameObject progressBar;
    [SerializeField] private float progressBarIncrement;

    private float timer = 0f;


    const int SMALL_BIRD_TIME = 0; bool smallBirdOn = false;
    const int LARGE_BIRD_TIME = 30; bool largeBirdOn = false;
    const int MUD_TIME = 60; bool mudOn = false;
    const int CHECKPOINT1_END = 90; bool check1On = false;
    const int SEAT_BELT_TIME = 150; bool seatBeltOn = false;
    const int SIMON_SAYS_TIME = 165; bool simonOn = false;
    const int PASSWORD_TIME = 285; bool password = false;
    const int TURBULENCE_TIME = 405; bool turbulenceOn = false;
    const int FINAL_TIME = 465; bool finalOn = false;
    const int END_TIME = 645; bool endOn = false;

    private void Update()
    {
        timer += Time.deltaTime;

    }


    private void FixedUpdate()
    {
        progressBar.transform.position = progressBar.transform.position + new Vector3(-progressBarIncrement, 0, 0);
    }

}
