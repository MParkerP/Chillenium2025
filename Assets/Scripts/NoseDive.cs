using UnityEngine;

public class NoseDive : MonoBehaviour
{

    [SerializeField] private int quota;
    private int currentPresses;
    private bool currentlyDiving;

    void Start()
    {
        currentPresses = 0;
    }


    void Update()
    {
        //Checks if you are pressing the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("currentPresses + " + currentPresses);
            currentPresses++;
        }

        //Checks if you met the quota
        if (currentPresses >= quota)
        {
            currentlyDiving = false;
            currentPresses = 0;
        }

        //Adds danger level if still diving
        if (currentlyDiving) { }
    }
}
