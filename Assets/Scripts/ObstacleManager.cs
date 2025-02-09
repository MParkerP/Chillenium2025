using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;

    [SerializeField] private float leftMostX;
    [SerializeField] private float rightMostX;
    [SerializeField] private float lowerMostY;
    [SerializeField] private float upperMostY;

    [SerializeField] public enum dangerFactors {smallBird = 10, bigBird = 20 };

    [SerializeField] private static GameObject smallBirdObject;
    [SerializeField] private Vector2 smallBirdSpawnLocation;
    [SerializeField] private static float smallBirdDangerIncrement;
    [SerializeField] private static float smallBirdPassiveDangerFactor;

    [SerializeField] private GenericObstacle smallBird = new GenericObstacle(smallBirdObject, smallBirdPassiveDangerFactor, bigBirdInstantDangerIncrement);

    [SerializeField] private static GameObject bigBirdObject;
    [SerializeField] private static float bigBirdpassiveDangerFactor;
    [SerializeField] private static float bigBirdInstantDangerIncrement;
    [SerializeField] private Vector2 bigBirdSpawnPostion;

    [SerializeField] private GenericObstacle bigBird = new GenericObstacle(bigBirdObject, bigBirdpassiveDangerFactor, bigBirdInstantDangerIncrement);
    

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

        if(Input.GetKeyUp(KeyCode.B)) { Spawn_GenericObstacle(smallBird, smallBirdSpawnLocation); }
        if(Input.GetKeyUp(KeyCode.H)) { randomSpawn_GenericObstacle(bigBird); }
    }

    /*public GameObject Spawn_SmallBird()
    {
        GameObject smallBirdObject = Instantiate(smallBird, smallBirdSpawnLocation, Quaternion.identity);
        obstacles.Add(smallBirdObject);
        dangerLevelManager.RecieveNewObstacle(smallBirdDangerIncrement, smallBirdPassiveDangerFactor);
        return smallBirdObject;
    }*/

    [Serializable]
    public class GenericObstacle
    {
        public GameObject obstacle;
        public float passiveDangerFactor;
        public float instantDangerIncrement;

        public GenericObstacle(GameObject obstacle, float passiveDangerFactor, float instantDangerIncrement)
        {
            this.obstacle = obstacle;
            this.passiveDangerFactor = passiveDangerFactor;
            this.instantDangerIncrement = instantDangerIncrement;

        }
        
    }

    public GameObject Spawn_GenericObstacle(GenericObstacle obstacle, Vector2 spawnPosition)
    {
        GameObject thisObject = Instantiate(obstacle.obstacle, spawnPosition, Quaternion.identity);
        obstacles.Add(thisObject);
        dangerLevelManager.RecieveNewObstacle(obstacle.instantDangerIncrement, obstacle.passiveDangerFactor);
        return thisObject;
    }

    public GameObject randomSpawn_GenericObstacle(GenericObstacle obstacle)
    {
        float randomx = UnityEngine.Random.Range(leftMostX, rightMostX);
        float randomy = UnityEngine.Random.Range(lowerMostY, upperMostY);
        Vector2 position = new Vector2(randomx, randomy);
        GameObject thisObject = Instantiate(obstacle.obstacle, position, Quaternion.identity);
        obstacles.Add(thisObject);
        dangerLevelManager.RecieveNewObstacle(obstacle.instantDangerIncrement, obstacle.passiveDangerFactor);
        return thisObject;
    }

     

}


