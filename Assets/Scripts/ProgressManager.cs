using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private ObstacleManager obstacleManager;
    [SerializeField] private GameObject progressBar;
    [SerializeField] private float progressBarIncrement;
    [SerializeField] private float eventInterval;

    public GameObject smallBirdPrefab;
    public GameObject largeBirdPrefab;
    public GameObject mudPrefab;

    public AudioClip windowThud;
    public AudioClip mudSplat;
    private AudioSource audioSource;
    public HappinessScript happinessScript;

    public SimonSays simonSays;


    public float timer = 0f;


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

    public bool gameStart = false;

    List<Action> possibleEvents = new List<Action>();

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        obstacleManager = GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>();
    }

    private void Update()
    {
        if (gameStart)
        {
            timer += Time.deltaTime;

            if (timer >= SMALL_BIRD_TIME && !smallBirdOn)
            {
                smallBirdOn = true;
                StartCoroutine(SmallBird());
            }

            if (timer >= LARGE_BIRD_TIME && !largeBirdOn)
            {
                largeBirdOn = true;
                StartCoroutine(LargeBird());
            }

            if (timer >= MUD_TIME && !mudOn)
            {
                mudOn = true;
                StartCoroutine(Mud());
            }

            if (timer >= CHECKPOINT1_END && !check1On)
            {
                check1On = true;
                StartCoroutine(BeginEvents());
            }

            if (timer >= SEAT_BELT_TIME && !seatBeltOn)
            {
                seatBeltOn = true;
                happinessScript.StartButtonStuff();
            }

            if (timer >= SIMON_SAYS_TIME && !simonOn)
            {
                simonOn = true;
                happinessScript.StartButtonStuff();
            }
        }
    }


    private void FixedUpdate()
    {
        progressBar.transform.position = progressBar.transform.position + new Vector3(-progressBarIncrement, 0, 0);
    }

    IEnumerator SmallBird()
    {
        while (true)
        {
            float spawnChance = 0.5f;
            float spawnChanceInterval = 2f;
            if (UnityEngine.Random.value < spawnChance)
            {
                obstacleManager.randomSpawn_GenericObstacle(obstacleManager.smallBird);
                audioSource.PlayOneShot(windowThud);
            }
            yield return new WaitForSeconds(spawnChanceInterval);
        }
    }

    IEnumerator LargeBird()
    {
        while (true)
        {
            float spawnChance = 0.35f;
            float spawnChanceInterval = 5f;
            if (UnityEngine.Random.value < spawnChance)
            {
                obstacleManager.randomSpawn_GenericObstacle(obstacleManager.bigBird);
                audioSource.PlayOneShot(windowThud);
            }
            yield return new WaitForSeconds(spawnChanceInterval);
        }
    }

    IEnumerator Mud()
    {
        while (true)
        {
            float spawnChance = 0.35f;
            float spawnChanceInterval = 5f;
            if (UnityEngine.Random.value < spawnChance)
            {
                obstacleManager.randomSpawn_GenericObstacle(obstacleManager.mud);
                audioSource.PlayOneShot(mudSplat);
            }
            yield return new WaitForSeconds(spawnChanceInterval);
        }
    }

    IEnumerator BeginEvents()
    {
        while (true)
        {
            int func = UnityEngine.Random.Range(0, possibleEvents.Count + 1);
            possibleEvents[func]?.Invoke();
            yield return new WaitForSeconds(eventInterval);
        }
    }



}
