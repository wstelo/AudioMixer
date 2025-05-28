using UnityEngine;
using UnityEngine.UI;

public class PlayClipButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;

    private void OnEnable()
    {
        _button.onClick.AddListener(StartAudio);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartAudio);
    }

    private void StartAudio()
    {
        _source.Stop();
       _source.PlayOneShot(_clip);
    }
}
