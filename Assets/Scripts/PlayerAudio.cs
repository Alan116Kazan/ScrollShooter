using UnityEngine;

/// <summary>
/// Управляет звуками игрока, такими как бег, полет и натяжение тетивы.
/// </summary>
public class PlayerAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Воспроизводит заданный звук, если он еще не играет.
    /// </summary>
    /// <param name="clip">Аудиофайл для воспроизведения.</param>
    private void PlaySound(AudioClip clip)
    {
        if (_audioSource.clip != clip || !_audioSource.isPlaying)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }

    /// <summary>
    /// Останавливает текущий звук.
    /// </summary>
    public void StopSound()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }
}