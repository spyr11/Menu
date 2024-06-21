using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SfxButton : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSfx;

    private Button _button;

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
    }
}