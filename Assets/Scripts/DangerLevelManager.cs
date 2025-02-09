using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class DangerLevelManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float maxDanger;
    [SerializeField] private float startingDanger = 0;
    [SerializeField] private float totalPassiveDangerFactor = 0;
    [SerializeField] private float passiveDangerScaler;
    [SerializeField] private float passiveDangerDecayIncr;

    [SerializeField] private GameObject lossCanvas;
    public HappinessScript happinessScript;

    
    private void Start()
    {
        slider.value = startingDanger;
        slider.maxValue = maxDanger;
    }

    private void Update()
    {
        if (slider.value >= slider.maxValue) 
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        lossCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    

    private void FixedUpdate()
    {
        slider.value += totalPassiveDangerFactor * passiveDangerScaler * happinessScript.modifier;

        if (totalPassiveDangerFactor <= 0)
        {
            slider.value -= passiveDangerDecayIncr * passiveDangerScaler;
        }
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
        IncreasePassiveDangerFactor(passiveDangerFactor);
    }

    public void IncreasePassiveDangerFactor(float dangerFactor)
    {
        totalPassiveDangerFactor += dangerFactor;
    }

    public void DecreasePassiveDangerFactor(float dangerFactor)
    {
        totalPassiveDangerFactor -= dangerFactor;
    }


}
