using UnityEngine;

public class GenericObstacle : MonoBehaviour
{
    DangerLevelManager dangerLevelManager;
    [SerializeField] ObstacleManager.dangerFactors passiveDangerFactor;
    private void Start()
    {
        dangerLevelManager = GameObject.Find("DangerLevelManager").GetComponent<DangerLevelManager>();
    }

    private void OnDestroy()
    {
        dangerLevelManager.DecreasePassiveDangerFactor((float)passiveDangerFactor);
    }
}
