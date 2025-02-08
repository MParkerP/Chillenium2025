using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class DangerLevelManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float maxDanger;
    [SerializeField] private float startingDanger = 0;
    [SerializeField] private float totalPassiveDangerFactor = 0;

    private void Start()
    {
        slider.value = startingDanger;
        slider.maxValue = maxDanger;
    }

    public void IncreaseDangerLevelOnce(float dangerIncrement)
    {
        slider.value += dangerIncrement;
    }

    public void DecreaseDangerLevelOnce(float dangerIncrement)
    {
        slider.value -= dangerIncrement;
    }

    public void RecieveNewObstacle(float dangerIncrementInstant, float passiveDangerFactor)
    {
        IncreaseDangerLevelOnce(dangerIncrementInstant);

    }

    public void IncreasePassiveDangerFactor(float dangerFactor)
    {
        totalPassiveDangerFactor += dangerFactor;
    }


}
