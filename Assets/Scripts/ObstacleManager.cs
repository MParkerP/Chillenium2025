using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;

    [SerializeField] private GameObject smallBird;
    [SerializeField] private Vector2 smallBirdSpawnLocation;
    [SerializeField] private float smallBirdDangerIncrement;
    [SerializeField] private float smallBirdPassiveDangerFactor;

    private DangerLevelManager dangerLevelManager;

    private void Start()
    {
        dangerLevelManager = GameObject.Find("DangerLevelManager").GetComponent<DangerLevelManager>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.D))
        {
            foreach (GameObject obstacle in obstacles) { GameObject.Destroy(obstacle); }
        }

        if(Input.GetKeyUp(KeyCode.B)) { Spawn_SmallBird(); }
    }

    public GameObject Spawn_SmallBird()
    {
        GameObject smallBirdObject = Instantiate(smallBird, smallBirdSpawnLocation, Quaternion.identity);
        obstacles.Add(smallBirdObject);
        dangerLevelManager.RecieveNewObstacle(smallBirdDangerIncrement, smallBirdPassiveDangerFactor);
        return smallBirdObject;
    }
    
}
