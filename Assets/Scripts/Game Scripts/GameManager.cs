using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    // Inspector references
    [Header("UI Panels")]
    public GameObject endPanel;

    [Header("End Screen Buttons")]
    public Button replayButton;
    public Button quitButton;

    [Header("Player")]
    public Transform player;

    // Singleton
    public static GameManager Instance;

    [Header("Game Over Text")]
    public TextMeshProUGUI GameOverText;

    void Awake () {
        Instance = this;
    }

    void Start () {
        if (endPanel != null) endPanel.SetActive(false);

        if (replayButton != null) replayButton.onClick.AddListener(ReplayGame);
        if (quitButton   != null) quitButton.onClick.AddListener(QuitGame);

        Time.timeScale = 1f;
    }
    
    public void PlayerEnteredWater () {
        player.GetComponent<PlayerDamage>().DealDamage();
    }

    IEnumerator RespawnPlayer () {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;

        if (player != null) {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            Vector3 respawnPos = pm != null ? pm.lastSafePosition : player.position;
            respawnPos.y += 2f;
            player.position = respawnPos;
        }
    }

    public void ShowEndScreen () {
        Time.timeScale = 0f;
        FindFirstObjectByType<GameTimer>()?.SetTimerRunning(false);
        if (GameOverText != null) GameOverText.text = "Game Over!";
        if (endPanel != null) endPanel.SetActive(true);
    }

    public void ShowWinScreen () {
    Time.timeScale = 0f;
    FindFirstObjectByType<GameTimer>()?.SetTimerRunning(false);
    if (GameOverText != null) GameOverText.text = "YOU WIN!";
    if (endPanel != null) endPanel.SetActive(true);
    }
    

    public void ReplayGame () {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame () {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}  // class GameManager
