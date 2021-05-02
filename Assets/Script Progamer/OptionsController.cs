using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0f;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();//volume hiện tại
        difficultySlider.value = PlayerPrefsController.GetDifficulty();//difficulty hiện tại
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();//cập nhật thay đổi volume
        if (musicPlayer)
        {
            //Debug.Log("Master volume set to " + volumeSlider.value);
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }


    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }


    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
        Debug.Log("Master volume set to default: " + defaultVolume + " ======== " + "Difficulty set to: " + defaultDifficulty);
    }
}
