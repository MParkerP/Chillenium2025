using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class SimonSays : MonoBehaviour
{
    /*
    * To use this script, create an empty game object and put this script on it
    * Give the buttons the "ShapeButton" script, and assign Simon to the empty object
    * Set its name to its respective shape:
    * Rectangle = r || diamond = d || circle = c || triangle = t
    * Everything should work :D
    */

    public int simonLength;
    private string sequence;
    private string InputSequence;
    private bool enabled;
    [SerializeField] private ShapeButton s;
    [SerializeField] private ShapeButton d;
    [SerializeField] private ShapeButton t;
    [SerializeField] private ShapeButton c;

    public DangerLevelManager dangerLevelManager;
    public float dangerfactor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputSequence = "";
        sequence = generateSequence();
        lowerAll();
        //raiseAll();
    }


    string generateSequence()
    {
        string sequenceString = "tsdc";
        char[] sequenceArray = sequenceString.ToCharArray();

        for (int i = 0; i < 15; i++)
        {
            int choice = Random.Range(0, 4);
            char tmp = sequenceArray[i % 4];
            sequenceArray[i % 4] = sequenceArray[choice];
            sequenceArray[choice] = tmp;
        }

        return new string(sequenceArray);
    }

    public void recieveInput(string color)
    {
        if (!enabled) { return; }
        InputSequence += color;
        if (InputSequence.Length >= simonLength)
        {
            string trunicated = InputSequence.Substring(InputSequence.Length - simonLength);
            validateInput(trunicated);
        }
        else
        {
            validateInput(InputSequence);
        }
    }


    private void validateInput(string input)
    {
        // Debug.Log(input);
        if (string.Equals(input, sequence.Substring(0, input.Length)))
        {
            if (input.Length == simonLength) { win(); }
            lower(input[input.Length-1]);
           
            return;

        }
        else
        {
            lose();
        }

    }

    private void lower(char letter)
    {
        switch(letter){
            case 's':
                s.lower();
                break;
            case 't':
                t.lower();
                break;
            case 'd':
                d.lower();
                break;
            case 'c':
                c.lower();
                break;
        }
    }
    private void win()
    {
        //keep buttons depressed
        dangerLevelManager.DecreasePassiveDangerFactor(dangerfactor);
        StopAllCoroutines();
    }

    private void lose()
    {
        //lift up the buttons
        Debug.Log("You lost");
        dangerLevelManager.IncreaseDangerLevelOnce(100);
        InputSequence = "";
        raiseAll();
    }


    private void raiseAll()
    {
        t.raise();
        s.raise();
        c.raise();
        d.raise();
    }

    private void lowerAll()
    {
        t.lower();
        s.lower();
        c.lower();
        d.lower();
    }

    IEnumerator flashSequence()
    {
        for (int i = 0; i < simonLength; i++)
        {
            switch (sequence[i])
            {
                case 's': s.toggleLight(); yield return new WaitForSeconds(1f); s.toggleLight(); break;
                case 't': t.toggleLight(); yield return new WaitForSeconds(1f); t.toggleLight(); break;
                case 'd': d.toggleLight(); yield return new WaitForSeconds(1f); d.toggleLight(); break;
                case 'c': c.toggleLight(); yield return new WaitForSeconds(1f); c.toggleLight(); break;
                default: break;
            }
            yield return new WaitForSeconds(0.25f);
        }
        dangerLevelManager.IncreasePassiveDangerFactor(dangerfactor);
    }

    IEnumerator triggerFlash()
    {
        while (true)
        {
            if (enabled)
            {
                StartCoroutine(flashSequence());
            }
            else
            {
                Debug.Log("I ran but didnt flash");
            }
            yield return new WaitForSeconds(10f);
        }
    }

    public void enableGame()
    {
        enabled = true;
        generateSequence();
        StartCoroutine(triggerFlash());
        raiseAll();
    }



}