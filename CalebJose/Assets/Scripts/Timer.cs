using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float StartingTime = 10f;

    [SerializeField] TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            Restart();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
