using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class SettingsManager : MonoBehaviour
{
    [Header("Toggle Buttons")]
    public Button soundToggleButton;
    public Button musicToggleButton;

    [Header("Player Name")]
    public GameObject nameInputPanel;
    public Button changeNameButton;
    public TMP_InputField playerNameInput;
    public Button confirmNameButton;

    [Header("Settings Panel Controls")]
    public Button closeSettingsButton;
    public GameObject settingsPanel;

    private bool soundOn;
    private bool musicOn;

    void Start()
    {
        // Load settings
        soundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        playerNameInput.text = PlayerPrefs.GetString("PlayerName", "Player");

        // Set up button actions
        soundToggleButton.onClick.AddListener(ToggleSound);
        musicToggleButton.onClick.AddListener(ToggleMusic);
        changeNameButton.onClick.AddListener(ShowNameInput);
        confirmNameButton.onClick.AddListener(ConfirmName);
        closeSettingsButton.onClick.AddListener(CloseSettings);

        // Hide name editor at start
        nameInputPanel.SetActive(false);

        // Apply initial audio setting
        AudioListener.volume = soundOn ? 1f : 0f;
    }

    void ToggleSound()
    {
        soundOn = !soundOn;
        PlayerPrefs.SetInt("SoundOn", soundOn ? 1 : 0);
        AudioListener.volume = soundOn ? 1f : 0f;
        Debug.Log("Sound: " + (soundOn ? "On" : "Off"));
    }

    void ToggleMusic()
    {
        musicOn = !musicOn;
        PlayerPrefs.SetInt("MusicOn", musicOn ? 1 : 0);
        Debug.Log("Music: " + (musicOn ? "On" : "Off"));
        // Optional: Add your own music audio source mute/unmute here
    }

    void ShowNameInput()
    {
        nameInputPanel.SetActive(true);
    }

    void ConfirmName()
    {
        string newName = playerNameInput.text;
        PlayerPrefs.SetString("PlayerName", newName);
        nameInputPanel.SetActive(false);
        Debug.Log("Player name set to: " + newName);
    }

    void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}


