using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private AudioListener _listener;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(MuteAudio);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(MuteAudio);
    }

    private void MuteAudio(bool isActive)
    {
        if (isActive)
        {
            _listener.enabled = true;
        }
        else
        {
            _listener.enabled = false;
        }
    }
}
