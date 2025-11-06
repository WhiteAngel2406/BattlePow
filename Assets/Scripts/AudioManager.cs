using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField] AudioSource effectAudioSource;
	[SerializeField] AudioSource defaultAudioSource;
	[SerializeField] AudioSource bossAudioSource;
	[SerializeField] AudioClip Shotclip;
	[SerializeField] AudioClip ReloadClip;
	[SerializeField] AudioClip EnergyClip;

    private void Start()
    {
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 1f);

        SetMusicVolume(musicVol);
        SetSFXVolume(sfxVol);
    }

    public void PlayShot()
	{
		effectAudioSource.PlayOneShot(Shotclip);
	}

	public void PlayReload()
	{
		effectAudioSource.PlayOneShot(ReloadClip);
	}

	public void PlayEnerty()
	{
		effectAudioSource.PlayOneShot(EnergyClip);
	}

	public void PlayDefaultAudio()
	{
		bossAudioSource.Stop();
		defaultAudioSource.Play();
	}
	public void PlayBossAudio()
	{
		defaultAudioSource.Stop();
		bossAudioSource.Play();
	}

	public void StopAudioGame()
	{
		effectAudioSource.Stop();
		defaultAudioSource.Stop();
		bossAudioSource.Stop();
	}

    public void SetMusicVolume(float volume)
    {
        defaultAudioSource.volume = volume;
        bossAudioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        if (!defaultAudioSource.isPlaying && !bossAudioSource.isPlaying)
        {
            defaultAudioSource.Play();
        }
    }

    public void SetSFXVolume(float volume)
    {
        effectAudioSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
        if (!effectAudioSource.isPlaying)
        {
            effectAudioSource.PlayOneShot(Shotclip);
        }
    }
}
