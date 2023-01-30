using UnityEngine;
using Utilities;

/// <summary>
/// Управление звуковыми ресурсами
/// </summary>
public class AudioSystem : Singleton<AudioSystem>
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundsSource;

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void PlaySound(AudioClip clip, Vector3 position, float volume = 1)
    {
        _soundsSource.transform.position = position;
        PlaySound(clip, volume);
    }

    public void PlaySound(AudioClip clip, float volume = 1)
    {
        _soundsSource.PlayOneShot(clip, volume);
    }
}
