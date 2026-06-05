using UnityEngine;

public class WaterZone : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            GameManager.Instance.PlayerEnteredWater();
        }
    }

}  // class WaterZone
