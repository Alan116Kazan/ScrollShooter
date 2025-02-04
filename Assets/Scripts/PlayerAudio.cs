using UnityEngine;

/// <summary>
/// ��������� ������� ������, ������ ��� ���, ����� � ��������� ������.
/// </summary>
public class PlayerAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// ������������� �������� ����, ���� �� ��� �� ������.
    /// </summary>
    /// <param name="clip">��������� ��� ���������������.</param>
    private void PlaySound(AudioClip clip)
    {
        if (_audioSource.clip != clip || !_audioSource.isPlaying)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }

    /// <summary>
    /// ������������� ������� ����.
    /// </summary>
    public void StopSound()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }
}