using UnityEngine;
using UnityEngine.UI;

public class HappinessScript : MonoBehaviour
{
    private bool seatBeltSign = false;
    [SerializeField] private float total;
    [SerializeField] private float decrementAmount;
    [SerializeField] private float incrementAmount;
    [SerializeField] private float happinessLevel = 100;
    [SerializeField] private float modifier = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            happinessLevel -= decrementAmount;
        }
        else
        {
            happinessLevel += incrementAmount;
        }
    }

    private void Limits()
    {
        if (happinessLevel > total)
        {
            happinessLevel = total;
        }
        if (happinessLevel < 0)
        {
            happinessLevel = 0;
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
}
