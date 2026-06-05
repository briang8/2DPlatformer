using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public GameObject settingsPanel;
    public Toggle musicToggle;
    public Slider musicVolumeSlider;
    public AudioSource musicSource;

    private const string MUSIC_KEY = "MusicEnabled";
    private const string VOLUME_KEY = "MusicVolume";

    void Start () {
        settingsPanel.SetActive(false);

        bool musicOn = PlayerPrefs.GetInt(MUSIC_KEY, 1) == 1;
        musicToggle.isOn = musicOn;
        musicToggle.onValueChanged.AddListener(OnMusicToggled);

        float savedVolume = PlayerPrefs.GetFloat(VOLUME_KEY, 1f);
        musicVolumeSlider.minValue = 0f;
        musicVolumeSlider.maxValue = 1f;
        musicVolumeSlider.value = savedVolume;
        musicVolumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        // Apply saved settings to the AudioSource immediately
        musicSource.volume = savedVolume;
        if (musicOn) musicSource.Play();
        else musicSource.Stop();
    }

    public void OpenSettings () {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings () {
        settingsPanel.SetActive(false);
    }

    void OnMusicToggled (bool isOn) {
        PlayerPrefs.SetInt(MUSIC_KEY, isOn ? 1 : 0);
        PlayerPrefs.Save();

        if (isOn) musicSource.Play();
        else musicSource.Stop();
    }

    void OnVolumeChanged (float value) {
        PlayerPrefs.SetFloat(VOLUME_KEY, value);
        PlayerPrefs.Save();
        musicSource.volume = value;
    }

}