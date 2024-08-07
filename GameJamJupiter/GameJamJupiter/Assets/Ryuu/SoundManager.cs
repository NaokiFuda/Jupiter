using UnityEngine;
using UnityEngine.Audio;

[DefaultExecutionOrder(-100)]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;


    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] AudioSource _bgmAudioSource;
    [SerializeField] AudioSource _seAudioSource;

    protected void Awake()
    {
        if (_bgmAudioSource == null) Debug.LogError("BGM AudioSource is null.");
        if (_seAudioSource == null) Debug.LogError("SE AudioSource is null.");
        if (_audioMixer == null) Debug.LogError("Audio Mixer is null.");

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary> BGMを再生 </summary> ///
    public void PlayBGM(AudioClip audioClipBGM)
    {
        _bgmAudioSource.clip = audioClipBGM;
        _bgmAudioSource.Play();
    }

    /// <summary> SEを再生 </summary> ///
    public void PlaySE(AudioClip audioClipSE)
    {
        _seAudioSource.PlayOneShot(audioClipSE);
    }

    public void MuteBGM(bool mute)
    {
        _bgmAudioSource.mute = mute;
    }

    public void MuteSE(bool mute)
    {
        _seAudioSource.mute = mute;
    }

    public void SetVolumeBGM(float volume)
    {
        _audioMixer.SetFloat("BGM", volume);
    }
    
    public void SetVolumeSE(float volume)
    {
        _audioMixer.SetFloat("SE", volume);
    }
    
    
}
