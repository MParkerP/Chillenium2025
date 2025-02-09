using UnityEngine;

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
    [SerializeField] private ShapeButton s;
    [SerializeField] private ShapeButton d;
    [SerializeField] private ShapeButton t;
    [SerializeField] private ShapeButton c;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputSequence = "";
        sequence = generateSequence();
        raiseAll();
    }


    string generateSequence()
    {
        //Later replace with predefined sequences
        string sequenceString = "";
        for (int i = 0; i < simonLength; i++)
        {
            int choice = Random.Range(0, 4);
            switch (choice)
            {
                case 0: sequenceString += "s"; break;
                case 1: sequenceString += "t"; break;
                case 2: sequenceString += "c"; break;
                case 3: sequenceString += "d"; break;
                default: break;
            }
        }
        //Debug.Log("Looking for: " + sequenceString);
        return "cstd";
    }

    public void recieveInput(string color)
    {
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

            return;

        }
        else
        {
            lose();
        }

    }

    private void win()
    {
        //keep buttons depressed
        Debug.Log("You won shape game");
    }

    private void lose()
    {
        //lift up the buttons
        Debug.Log("You lost");
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
}