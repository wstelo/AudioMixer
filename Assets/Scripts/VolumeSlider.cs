using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private string _exposedParameter;
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixerGroup _mixerGroup;
    private float _currentVolume = 0;
    private float _multipleIndex = 20;
    private float _minValueInDecibels = -80;

    public float CurrentVolume => _currentVolume;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeValue);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeValue);
    }

    public void ChangeValue(float volume)
    {
        if (volume == 0)
        {
            _currentVolume = _minValueInDecibels;
        }
        else
        {
            _currentVolume = Mathf.Log(volume) * _multipleIndex;
        }

        _mixerGroup.audioMixer.SetFloat(_exposedParameter, _currentVolume);
    }
}
