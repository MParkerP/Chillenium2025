using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFeatherScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator animator;
    [SerializeField] GameObject feather;
    [SerializeField] private int numFeathers;
    private DangerLevelManager dangerLevelManager;
    private ObstacleManager obstacleManager;
    public float featherpassivedanger;
    void Start()
    {
        dangerLevelManager = GameObject.Find("DangerLevelManager").GetComponent<DangerLevelManager>();
        obstacleManager = GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>();
        StartCoroutine(SpawnFeathers());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnFeathers()
    {
        yield return new WaitForSeconds(0.21f);
        
        for (int i = 0; i < numFeathers; i++)
        {
            Instantiate(feather, transform.position, transform.rotation);
            dangerLevelManager.IncreasePassiveDangerFactor(2);
        }
    }
}
