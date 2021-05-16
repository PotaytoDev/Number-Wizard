using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int maxNumberRange = 1000;
        int minNumberRange = 1;

        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("In this game, I will guess the number you are thinking of from a given range.");
        Debug.Log("Pick a number from " + minNumberRange + " to " + maxNumberRange + ": ");
        Debug.Log("Tell me if your number is lower or higher than 500");
        Debug.Log("Press Up Arrow (Higher), Down Arrow (Lower), or Enter/Return (Correct guess)");
    }

    // Update is called once per frame
    void Update()
    {
        // This means that the number is higher than the guess
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow key was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down arrow key was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Return/Enter key was pressed.");
        }
    }
}
