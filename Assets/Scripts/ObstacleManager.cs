using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;

    //BirdLimits
    [SerializeField] private float leftMostX; 
    [SerializeField] private float rightMostX;
    [SerializeField] private float lowerMostY;
    [SerializeField] private float upperMostY;

    [SerializeField] private float dropletleftMostX;
    [SerializeField] private float dropletrightMostX;
    [SerializeField] private float dropletowerMostY;
    [SerializeField] private float dropletupperMostY;

    [SerializeField] public enum dangerFactors {smallBird = 10, bigBird = 20, droplet = 1 , feathers = 2, mud = 15};

    [SerializeField] private static GameObject smallBirdObject;
    [SerializeField] private Vector2 smallBirdSpawnLocation;
    [SerializeField] private static float smallBirdDangerIncrement;
    [SerializeField] private static float smallBirdPassiveDangerFactor;

    [SerializeField] public GenericObstacle smallBird = new GenericObstacle(smallBirdObject, smallBirdPassiveDangerFactor, bigBirdInstantDangerIncrement);

    [SerializeField] private static GameObject bigBirdObject;
    [SerializeField] private static float bigBirdpassiveDangerFactor;
    [SerializeField] private static float bigBirdInstantDangerIncrement;
    [SerializeField] private Vector2 bigBirdSpawnPostion;

    [SerializeField] public GenericObstacle bigBird = new GenericObstacle(bigBirdObject, bigBirdpassiveDangerFactor, bigBirdInstantDangerIncrement);

    [SerializeField] private static GameObject dropletObject;
    [SerializeField] private static float dropletpassiveDangerFactor;
    [SerializeField] private static float dropletInstantDangerIncrement;
    [SerializeField] private Vector2 dropletSpawnPostion;

    [SerializeField] public GenericObstacle droplet = new GenericObstacle(dropletObject, dropletpassiveDangerFactor, dropletInstantDangerIncrement);

    [SerializeField] private static GameObject mudObject;
    [SerializeField] private static float mudPassiveDangerFactor;
    [SerializeField] private static float mudInstantDangerIncrement;
    [SerializeField] private Vector2 mudSpawnPosition;

    [SerializeField] public GenericObstacle mud = new GenericObstacle(mudObject, mudPassiveDangerFactor, mudInstantDangerIncrement);


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
        if(Input.GetKeyUp(KeyCode.W)) { randomSpawn_GenericObstacle(droplet,-8.7f,8.7f,-0.3f,5); }
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

    public GameObject randomSpawn_GenericObstacle(GenericObstacle obstacle, float leftMostX = -8,float rightMostX = 8,float lowerMostY = 0, float upperMostY = 4)
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


