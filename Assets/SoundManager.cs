using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AudioSource;


    public AudioClip[] clips;


    private PlayerStateController _playerStateController;

    private void Start()
    {
        _playerStateController = PlayerStateController.Instance;
        
        _playerStateController.playerStateChanged += ChangeMusic;

    }

    private void OnDestroy()
    {
        if (_playerStateController != null)
        {
            _playerStateController.playerStateChanged -= ChangeMusic;
        }
    }

    private void ChangeMusic(PlayerState state)
    {
        if (state == PlayerState.Home)
        {
            AudioSource.clip = clips[0];
        }
        else if (state == PlayerState.Assembled)
        {
            AudioSource.clip = clips[1];
        }
        
        AudioSource.Play();
    }

    public void ToggleMusic(bool toggle)
    {
        AudioSource.mute = !toggle;
    }
    
}
