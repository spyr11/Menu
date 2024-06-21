using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;

    private void Start()
    {
        _musicSource.Play();
    }
}