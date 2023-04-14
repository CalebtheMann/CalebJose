/*****************************************************************************
// File Name : Timer.cs
// Author : Jose Becerra
// Last Edited by: Caleb Purnell
// Creation Date : April 6, 2023
//
// Brief Description : This script controls the timer at the top of the screen, 
which will show how much time players have to complete the level before running
out of oxygen.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    // Creates variables for the current time and the starting time
    float currentTime;
    public float StartingTime = 10f;

    // UI for timer text variable
    [SerializeField] TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        // the current time is = to the starting time
        currentTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        // every second, one is reduced from the total in the timer
        currentTime -= 1 * Time.deltaTime;
        // display the timer in the UI text
        countdownText.text = currentTime.ToString("0");

        // if the current time is less than or equal to 0
        if (currentTime <= 0)
        {
            // set the current time to 0 and run the restart function
            currentTime = 0;
            Restart();
        }
    }

    /// <summary>
    /// Restart function that will restart the scene
    /// </summary>
    private void Restart()
    {
        // Loads the Scene again restarting the game
        SceneManager.LoadScene("SampleScene");
    }
}
