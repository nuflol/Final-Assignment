using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    [SerializeField] private AudioClip musicOnStart;
    private AudioSource _audioSource;
    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        Play(musicOnStart, true);
    }

    private AudioClip _switchTo;
    
    public void Play(AudioClip music, bool interupt) {
        // Ignores transition delay if asked
        if (interupt == true) {
            _volume = 0.4f;
            _audioSource.volume = _volume;
            _audioSource.clip = music;
            _audioSource.Play();
        }
        else {
            _switchTo = music;
            StartCoroutine(SmoothMusicTransition());    
        }
    }
    private float _volume;
    [SerializeField] private float timeToSwitch;
    // Smoothly lowers volume and increase it to create transition
    IEnumerator SmoothMusicTransition() {
        _volume = 0.4f;

        while (_volume > 0f) {
            _volume -= Time.deltaTime / timeToSwitch;
            if (_volume < 0f) { _volume = 0f; }
            _audioSource.volume = _volume;
            yield return new WaitForEndOfFrame();
        }
        Play(_switchTo, true);
    }
}
