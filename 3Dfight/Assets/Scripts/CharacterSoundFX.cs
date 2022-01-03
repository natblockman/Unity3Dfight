using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour
{

    private AudioSource soundFX;

    public AudioClip attackSound1, attackSound2,dieSound;

    void Awake()
    {
        soundFX = GetComponent<AudioSource>();
    }

    public void Attack_Sound1()
    {
        soundFX.clip = attackSound1;
        soundFX.Play();
    }
    public void Attack_Sound2()
    {
        soundFX.clip = attackSound2;
        soundFX.Play();
    }
    public void DieSound()
    {
        soundFX.clip = dieSound;
        soundFX.Play();
    }
}
