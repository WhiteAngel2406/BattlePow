using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        // Lấy giá trị âm lượng đã lưu
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Gán sự kiện khi kéo thanh trượt
        musicSlider.onValueChanged.AddListener(audioManager.SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(audioManager.SetSFXVolume);
    }

    private void SetMusicVolume(float value)
    {
        audioManager.SetMusicVolume(value);
    }

    private void SetSFXVolume(float value)
    {
        audioManager.SetSFXVolume(value);
    }
}
