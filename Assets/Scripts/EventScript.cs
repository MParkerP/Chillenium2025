using System;
using System.Collections;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     ObstacleManager obstacleManager;
    [SerializeField] GameObject managerObject;
    bool rain = false;
    void Start()
    {
        obstacleManager = managerObject.GetComponent<ObstacleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartRain();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StopRain();
        }
    }

    IEnumerator SpawnSmallBirdFlock(int numBirds)
    {
        float waitTime;
        for (int i  = 0; i < numBirds; i++)
        {
            waitTime = UnityEngine.Random.Range(0.1f,0.5f);
            yield return new WaitForSeconds(waitTime);
            Debug.Log("made it");
            obstacleManager.randomSpawn_GenericObstacle(obstacleManager.smallBird);
        }
        Debug.Log("exit");

    }

    IEnumerator SpawnGroup(int numThings,ObstacleManager.GenericObstacle thing)
    {
        float waitTime;
        for (int i = 0; i < numThings; i++)
        {
            waitTime = UnityEngine.Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(waitTime);
            
            obstacleManager.randomSpawn_GenericObstacle(thing);
        }
    }

    public void StartRain()
    {
        rain = true;
    }
    private void FixedUpdate()
    {
        if(rain)
        {
            StartCoroutine(rainFall());
            Debug.Log("raining");
        }
    }

    public void StopRain()
    {
        rain = false;
    }
    IEnumerator rainFall()
    {
        float waitTime;
        waitTime = UnityEngine.Random.Range(1f, 1.5f);
        yield return new WaitForSeconds(waitTime);
        obstacleManager.randomSpawn_GenericObstacle(obstacleManager.droplet);
    }
}
