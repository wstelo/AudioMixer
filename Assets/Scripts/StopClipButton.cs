using UnityEngine;
using UnityEngine.UI;

public class StopClipButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _source;

    private void OnEnable()
    {
        _button.onClick.AddListener(EndAudio);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(EndAudio);
    }

    public void EndAudio()
    {
        _source?.Stop();
    }
}
