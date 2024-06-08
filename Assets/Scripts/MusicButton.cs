using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MusicButton : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSfx;
    [SerializeField] private AudioSource _audioMusic;

    private Button _button;

    public event Action<AudioSource> PlayStarted;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(StartPlay);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartPlay);
    }

    private void StartPlay()
    {
        _audioSfx.Play();

        PlayStarted?.Invoke(_audioMusic);
    }
}