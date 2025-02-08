using UnityEngine;

public class GenericObstacle : MonoBehaviour
{
    DangerLevelManager dangerLevelManager;
    [SerializeField] private float passiveDangerFactor;

    private void Start()
    {
        dangerLevelManager = GameObject.Find("DangerLevelManager").GetComponent<DangerLevelManager>();
    }

    private void OnDestroy()
    {
        dangerLevelManager.DecreasePassiveDangerFactor(passiveDangerFactor);
    }
}
