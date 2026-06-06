using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text coinTextScore;
	private AudioSource audioManager;
	private int scoreCount;
	private int totalCoins;
	private bool bossDefeated;

	void Awake() {
		audioManager = GetComponent<AudioSource> ();
	}

	void Start () {
		coinTextScore = GameObject.Find ("CoinText").GetComponent<Text> ();
		totalCoins = GameObject.FindGameObjectsWithTag(MyTags.COIN_TAG).Length;
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == MyTags.COIN_TAG) {
			
			target.gameObject.SetActive (false);
			scoreCount++;

			coinTextScore.text = "x" + scoreCount;

			audioManager.Play ();
			CheckWinCondition();
		}
	}

	public void BossDefeated () {
    bossDefeated = true;
    CheckWinCondition();
	}
	
	void CheckWinCondition () {
    if (bossDefeated && scoreCount >= totalCoins) {
        GameManager.Instance.ShowWinScreen();
		}
	}

} // class












































