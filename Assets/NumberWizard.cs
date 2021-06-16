using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // Declare variables
    int maxNumberRange;
    int minNumberRange;
    int guess;
    int maxNumberOfGuesses = 1;
    int currentNumberOfGuesses;
    int currentMax;
    int currentMin;
    bool gameIsOver;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        // Initialize variables
        maxNumberRange = 1000;
        minNumberRange = 1;
        currentMax = maxNumberRange;
        currentMin = minNumberRange;
        guess = (maxNumberRange + minNumberRange) / 2;
        currentNumberOfGuesses = 1;
        gameIsOver = false;

        // Find the maximum number of guesses that the program will need to take to guess the right number.
        FindNumberOfGuesses();

        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("In this game, I will guess the number you are thinking of and\n " +
            "I PROMISE you that I will find it within " + maxNumberOfGuesses + " guesses.");
        Debug.Log("First, pick a number from " + minNumberRange + " to " + maxNumberRange + ".");
        Debug.Log("Now, tell me if your number is lower or higher than " + guess);
        Debug.Log("Press Up Arrow (Higher), Down Arrow (Lower), or Enter (Correct guess)");

        // Need to make it 1001 because on the edge case where it's higher than 999, the result of the
        // calculation will give 999.5, which truncated into an integer is still 999. This will avoid that and give 1000.
        currentMax += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsOver)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentMin = guess;
                NextGuess();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentMax = guess;
                NextGuess();
            }
            else if (Input.GetKeyDown(KeyCode.Return) || currentNumberOfGuesses == maxNumberOfGuesses)
            {
                Debug.Log("I win :3");
                Debug.Log("And it took me " + currentNumberOfGuesses + " guesses!");
                Debug.Log("Press the Space key to play again.");
                gameIsOver = true;
            }
        }
        else if (gameIsOver && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    void NextGuess()
    {
        if (currentMax <= minNumberRange || currentMin >= maxNumberRange)
        {
            Debug.Log("You picked outside of the number range.");
            Debug.Log("Press the Space key to play again.");
            gameIsOver = true;
            return;
        }

        Debug.Log("This is guess number " + (++currentNumberOfGuesses));
        guess = (currentMax + currentMin) / 2;

        if (currentNumberOfGuesses < maxNumberOfGuesses)
        {
            Debug.Log("My guess is " + guess + ".\nIs your number higher, lower, or is my guess correct?");
        }
        else
        {
            Debug.Log("Your number is " + guess);
        }
    }

    private void FindNumberOfGuesses()
    {
        // This will loop in order to find the maximum number of guesses we are allowed to do based on
        // binary search and its log(n) run time
        while (Mathf.Pow(2, maxNumberOfGuesses) <= maxNumberRange)
        {
            maxNumberOfGuesses++;
        }
    }
}