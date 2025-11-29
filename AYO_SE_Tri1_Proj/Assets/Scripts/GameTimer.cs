using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text timerText;
    private readonly float countdownDuration = 90f; // 1.5 minutes countdown
    private float timeRemaining;

    public GameObject timeUpPanel;

    void Start()
    {
        //timerText = GetComponent<TMP_Text>();
        timeRemaining = countdownDuration;
        timeUpPanel.SetActive(false);
        StartCoroutine(UpdateTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator UpdateTimer()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
            yield return null;
        }
        DisplayTime(0);
        TimerFinished();

    }

    private void DisplayTime (float timeToDisplay)
    {
       
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        // separate minutes and seconds
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        // 
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void TimerFinished()
    {
        // show pop-up
        timeUpPanel.SetActive(true);

        // pause the game
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // unfreeze scene
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadMainScreen()
    {
        Time.timeScale = 1f; // unfreeze scene
        SceneManager.LoadScene("StartMenu");
    }
}
