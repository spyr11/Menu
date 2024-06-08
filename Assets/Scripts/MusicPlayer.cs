using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private MusicButton[] _buttons;

    private AudioSource _currentAudio;

    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            button.PlayStarted += OnPlayStarted;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            button.PlayStarted -= OnPlayStarted;
        }
    }

    private void OnPlayStarted(AudioSource audioSource)
    {
        if (_currentAudio != null)
        {
            _currentAudio.Stop();
        }

        _currentAudio = audioSource;

        _currentAudio.Play();
    }
}
