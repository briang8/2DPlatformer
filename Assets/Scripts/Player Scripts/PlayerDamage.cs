using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

	private Text lifeText;
	private int lifeScoreCount;

	private bool canDamage;

	private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;

	void Awake () {
		lifeText = GameObject.Find ("LifeText").GetComponent<Text> ();
		lifeScoreCount = 3;
		lifeText.text = "x" + lifeScoreCount;

		canDamage = true;
		spriteRenderer  = GetComponent<SpriteRenderer>();
        playerMovement  = GetComponent<PlayerMovement>();
	}

	void Start() {
		Time.timeScale = 1f;
	}
	
	public void DealDamage() {
		if (canDamage) {
			
			lifeScoreCount--;

			if (lifeScoreCount >= 0) {
				lifeText.text = "x" + lifeScoreCount;
			}

			if (lifeScoreCount == 0) {
            GameManager.Instance.ShowEndScreen();
            return;
			}

			canDamage = false;

			StartCoroutine (WaitForDamage ());
		}
	}

	IEnumerator WaitForDamage() {
    // Flash the player sprite for 2 seconds, then respawn to last safe ground position
    float elapsed = 0f;
    float duration = 2f;
    while (elapsed < duration) {
        spriteRenderer.enabled = !spriteRenderer.enabled;   // toggle visibility
        yield return new WaitForSeconds(0.15f);
        elapsed += 0.15f;
    }
    spriteRenderer.enabled = true;   // make sure sprite is visible after flashing

    // Teleport back to the last position the player stood on solid ground
    transform.position = playerMovement.lastSafePosition;

    canDamage = true;
	}

	

} // class

