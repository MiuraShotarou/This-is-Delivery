using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TitleAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _bgmSource;
    [SerializeField] AudioSource _seSource;
    [SerializeField] AudioClip[] _setBGMClipArray;
    [SerializeField] AudioClip[] _setSEClipArray;
    Dictionary<string, AudioClip> _seClipDict = new Dictionary<string, AudioClip>();
    Dictionary<string, AudioClip> _bgmClipDict = new Dictionary<string, AudioClip>();
    void Awake()
    {
        _seClipDict = _setSEClipArray.ToDictionary(clip => clip.name, clip => clip);
        _bgmClipDict = _setBGMClipArray.ToDictionary(clip => clip.name, clip => clip);
    }
    public void OnPlayBGM(string key)
    {
        _bgmSource.clip = _bgmClipDict[key];
        _bgmSource.clip.LoadAudioData();
        _bgmSource.Play();
    }
    public void OnPlaySE(string key)
    {
        _seSource.clip = _seClipDict[key];
        _seSource.clip.LoadAudioData();
        _seSource.Play();
    }
}
