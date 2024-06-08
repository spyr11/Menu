using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundPanel : MonoBehaviour
{
    private readonly float MaxDbValue = 20f;
    private readonly float MinDbValue = -80;

    [SerializeField] private OnOffButton _onOffButton;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _name;

    private bool _isEnabled = true;
    private string _description;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);

        if (_onOffButton != null)
        {
            _onOffButton.Toggled += OnToggled;
        }
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);

        if (_onOffButton != null)
        {
            _onOffButton.Toggled -= OnToggled;
        }
    }

    private void Start()
    {
        _description = _name + "Volume";

        if (PlayerPrefs.HasKey(_description))
        {
            LoadVolume();
        }
        else
        {
            SetVolume(_slider.value);
        }
    }

    private void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat(_description, volume);

        volume = _isEnabled ? volume : MinDbValue;

        _audioMixer.SetFloat(_name, Mathf.Log10(volume) * MaxDbValue);
    }

    private void LoadVolume()
    {
        _slider.value = PlayerPrefs.GetFloat(_description);

        SetVolume(_slider.value);
    }

    private void OnToggled(bool isEnabled)
    {
        _isEnabled = isEnabled;

        SetVolume(_slider.value);
    }
}