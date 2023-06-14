using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<Sounds> keys = new List<Sounds>();
    [SerializeField] private List<AudioSource> audios = new List<AudioSource>();
    public enum Sounds
    {
        UI_CLICK,
        ATTACK_SHOOT,
        ATTACK_IMPACT
    }

    public void playSound(Sounds sound)
    {
        int index = keys.IndexOf(sound);
        AudioSource audio = audios[index];
        audio.Play();
    }
}
