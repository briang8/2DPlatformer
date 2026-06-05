using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // ── Inspector references ─────────────────────────────────────
    [Header("UI Panels")]
    public GameObject endPanel;          // assign your End-screen panel

    [Header("End Screen Buttons")]
    public Button replayButton;          // assign Replay button
    public Button quitButton;            // assign Quit button

    [Header("Player")]
    public Transform player;             // assign Player transform

    // ── Singleton ────────────────────────────────────────────────
    public static GameManager Instance;

    void Awake () {
        Instance = this;
    }

    void Start () {
        // Hide end panel at game start
        if (endPanel != null) endPanel.SetActive(false);

        // Wire up button listeners
        if (replayButton != null) replayButton.onClick.AddListener(ReplayGame);
        if (quitButton   != null) quitButton.onClick.AddListener(QuitGame);

        // Store starting position as first safe position
        //if (player != null) lastSafePosition = player.position;

        Time.timeScale = 1f;
    }
    
    public void PlayerEnteredWater () {
    
    player.GetComponent<PlayerDamage>().DealDamage();
    }

    // Store safe ground position so respawn is close to the water

    IEnumerator RespawnPlayer () {
        // Brief pause so player sees they fell
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;

        // Teleport player slightly above last safe position
        if (player != null) {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            Vector3 respawnPos = pm != null ? pm.lastSafePosition : player.position;
            respawnPos.y += 2f;          // lift above ground to avoid clipping
            player.position = respawnPos;
        }
    }

    public void ShowEndScreen () {
        Time.timeScale = 0f;
        if (endPanel != null) endPanel.SetActive(true);
    }

    public void ReplayGame () {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame () {
        Application.Quit();
        // In the Editor, stop Play mode instead:
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}  // class GameManager
