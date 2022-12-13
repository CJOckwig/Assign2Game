using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    

    #region Aingleton Pattern
    

    #endregion

    [SerializeField] AudioSource[] _musicList;
    [SerializeField] AudioSource[] _sfxList;
    [SerializeField] int _levelMusicToPlay = 0;

    void Awake() 
    {

    }
    void Start()
    {
            
    }
    public void PlayMusic(int musicToPlay)
    {
        foreach(var music in _musicList)
        {
            music.Stop();
        }
        _musicList[_levelMusicToPlay].Play();

    }
    public void PlaySFX(int SFXToPlay)
    {
        foreach(var sfx in _sfxList)
        {
            sfx.Stop();
        }
        _sfxList[SFXToPlay].Play();
    }

    

}
