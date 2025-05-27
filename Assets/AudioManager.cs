using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mainMixerGroup;

    [Header ("Audio Clips")]
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip ClipOne;
    [SerializeField] private AudioClip ClipTwo;
    [SerializeField] private AudioClip ClipThree;

    private float _currentMainVolume = 0;
    private float _currentBackgroundVolume = 0;
    private float _timeToChangeSnapshot = 0.5f;
    private Coroutine _coroutine;

    public void ToggleMusic(bool isActive)
    {
        if (isActive)
        {
            _mainMixerGroup.audioMixer.SetFloat("MasterVolume", _currentMainVolume);
        }
        else
        {
            _mainMixerGroup.audioMixer.SetFloat("MasterVolume", -80);
        }
    }

    public void ChangeMainVolume(float volume)
    {
        _currentMainVolume = Mathf.Log(volume) * 20;
        _mainMixerGroup.audioMixer.SetFloat("MasterVolume", _currentMainVolume);
    }

    public void ChangeBackgroundVolume(float volume)
    {
        _currentBackgroundVolume = Mathf.Log(volume) * 20;
        _mainMixerGroup.audioMixer.SetFloat("BackgroundVolume", _currentBackgroundVolume);
    }

    public void ChangeClipVolume(float volume)
    {
        _mainMixerGroup.audioMixer.SetFloat("ClipsVolume", Mathf.Log(volume) * 20);
    }

    public void PlayClipOne()
    {
        _coroutine = StartCoroutine(DempingBackgroundVolume(ClipOne));
    }

    public void PlayClipTwo()
    {
        _coroutine =StartCoroutine(DempingBackgroundVolume(ClipTwo));
    }

    public void PlayClipThree()
    {
        _coroutine = StartCoroutine(DempingBackgroundVolume(ClipThree));
    }

    public void StopCurrentClip()
    {
        if(_coroutine != null)
        {
            _source.Stop();
            _mainMixerGroup.audioMixer.SetFloat("BackgroundVolume", _currentBackgroundVolume);
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator DempingBackgroundVolume(AudioClip clip)
    {
        _mainMixerGroup.audioMixer.SetFloat("BackgroundVolume", _currentBackgroundVolume - Mathf.Log(2) * 20);
        _source?.Stop();
        var wait = new WaitForSeconds(clip.length);
        _source.PlayOneShot(clip);
        yield return wait;
        _mainMixerGroup.audioMixer.SetFloat("BackgroundVolume", _currentBackgroundVolume);
    }
}
