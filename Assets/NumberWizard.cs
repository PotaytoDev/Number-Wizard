using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // Declare and initialize variables
    int maxNumberRange = 1000;
    int minNumberRange = 1;
    int guess = 500;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("In this game, I will guess the number you are thinking of from a given range.");
        Debug.Log("First, pick a number from " + minNumberRange + " to " + maxNumberRange + ".");
        Debug.Log("Now, tell me if your number is lower or higher than " + guess);
        Debug.Log("Press Up Arrow (Higher), Down Arrow (Lower), or Enter (Correct guess)");
        // Need to make it 1001 because on the edge case where it's higher than 999, the result of the
        // calculation will give 999.5, which truncated into an integer is still 999. This will avoid that and give 1000.
        maxNumberRange += 1;
    }

    // Update is called once per frame
    void Update()
    {
        // This means that the number is higher than the guess
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            minNumberRange = guess;
            guess = (maxNumberRange + minNumberRange) / 2;
            Debug.Log("My guess is " + guess + ". Is your number higher. lower, or is my guess correct?");
            Debug.Log("Press Up Arrow (Higher), Down Arrow (Lower), or Enter (Correct guess)");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            maxNumberRange = guess;
            guess = (maxNumberRange + minNumberRange) / 2;
            Debug.Log("My guess is " + guess + ". Is your number higher, lower, or is my guess correct?");
            Debug.Log("Press Up Arrow (Higher), Down Arrow (Lower), or Enter (Correct guess)");
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("The number you picked is: " + guess);
        }
    }
}
