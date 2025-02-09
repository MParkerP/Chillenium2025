using System;
using System.Collections;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     ObstacleManager obstacleManager;
    [SerializeField] GameObject managerObject;
    void Start()
    {
        obstacleManager = managerObject.GetComponent<ObstacleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(SpawnSmallBirdFlock(10));
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
}
