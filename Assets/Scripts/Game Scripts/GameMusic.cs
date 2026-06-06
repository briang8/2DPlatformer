using UnityEngine;

public class GameMusic : MonoBehaviour {

    private AudioSource musicSource;

    private const string MUSIC_KEY = "MusicEnabled";
    private const string VOLUME_KEY = "MusicVolume";

    void Start () {
        musicSource = GetComponent<AudioSource>();

        // Read saved preferences from main menu
        bool musicOn = PlayerPrefs.GetInt(MUSIC_KEY, 1) == 1;
        float volume  = PlayerPrefs.GetFloat(VOLUME_KEY, 1f);

        musicSource.volume = volume;

        if (musicOn) musicSource.Play();
        else musicSource.Stop();
    }

}