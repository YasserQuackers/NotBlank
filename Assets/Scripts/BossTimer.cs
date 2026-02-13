using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining = 60f;
    private bool isTimerRunning = true;

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                isTimerRunning = false;
                Debug.Log("Survival Complete!");
            }
        }
        if (timeRemaining <= 0)
        {
            PlayerWon();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PlayerWon()
    {
        SceneManager.LoadScene("PlayerWonScene");
    }
}
