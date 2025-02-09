using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HappinessScript : MonoBehaviour
{
    private bool seatBeltSign = false;
    [SerializeField] private float total;
    [SerializeField] private float decrementAmount;
    [SerializeField] private float incrementAmount;
    [SerializeField] private float happinessLevel = 100;
    [SerializeField] public float modifier = 1;
    [SerializeField] private Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue = total;
        slider.value = total;
        decrementAmount = 0;
        incrementAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Limits();
        increaseOrDecrease();
        boosters();
       
    }

    private void boosters()
    {
        if (seatBeltSign)
        {
            modifier = 1.2f;
        }
        else
        {
            modifier = 1;
        }
    }

    private void increaseOrDecrease()
    {
        if (seatBeltSign)
        {
            slider.value -= decrementAmount;
        }
        else
        {
            slider.value += incrementAmount;
        }
    }

    private void Limits()
    {
        if (slider.value > total)
        {
            slider.value = total;
        }
        if (slider.value < 0)
        {
            slider.value = 0;
        }
    }

    public void toggle()
    {
        if(seatBeltSign) { seatBeltSign = false; }
        else
        {
            seatBeltSign = true;
        }
    }

    public void StartButtonStuff()
    {
        decrementAmount = 0.1f;
        incrementAmount = 0.1f;
    }
}
