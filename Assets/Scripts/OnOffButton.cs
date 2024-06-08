using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OnOffButton : MonoBehaviour
{
    [SerializeField] private SoundPanel _audioMixer;
    [SerializeField] private string _name;

    [SerializeField] private Image _onImage;
    [SerializeField] private Image _offImage;

    private bool _isEnabled = true;
    private string _description;
    private Button _button;

    public event Action<bool> Toggled;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _description = _audioMixer.name;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Toggle);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Toggle);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(_description))
        {
            LoadToggle();
        }
        else
        {
            SetToggle(_isEnabled);
        }
    }

    private void Toggle()
    {
        _isEnabled = !_isEnabled;

        SetToggle(_isEnabled);
    }

    private void SetToggle(bool isEnabled)
    {
        _onImage.gameObject.SetActive(isEnabled);
        _offImage.gameObject.SetActive(isEnabled == false);

        Toggled?.Invoke(isEnabled);

        PlayerPrefs.SetString(_description, isEnabled.ToString());
    }

    private void LoadToggle()
    {
        _isEnabled = bool.Parse(PlayerPrefs.GetString(_description));

        SetToggle(_isEnabled);
    }
}