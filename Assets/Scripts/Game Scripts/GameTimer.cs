using System.Collections;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public float timeLimit = 120f;  // 2 minutes

    private float timeRemaining;
    private bool timerRunning;

    void Start () {
        timeRemaining = timeLimit;
        timerRunning = true;
    }

    void Update () {
        if (!timerRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f) {
            timeRemaining = 0f;
            timerRunning = false;
            UpdateDisplay(0f);
            GameManager.Instance.ShowEndScreen();
            return;
        }

        UpdateDisplay(timeRemaining);
    }

    void UpdateDisplay (float time) {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Call this to pause/resume the timer if needed
    public void SetTimerRunning (bool running) {
        timerRunning = running;
    }

}