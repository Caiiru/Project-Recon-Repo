﻿using UnityEngine;
using TMPro;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int maxHP;
    public int currentHP;
    public int damage;
    public int charSpeed;
    public GameObject floatintextPrefab;

    public AudioClip somDeAtaque;
    public AudioClip somDeTomarDano;
    public AudioClip somDeAndar;
    public AudioClip somDeMorte;
    
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (floatintextPrefab)
        {
            showFloatingText(dmg);
        }
        if (currentHP <= 0)
            return true;
        else
            return false;

    }

    public void cureHP(int cure)
    {
        currentHP += cure;

        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
    void showFloatingText(int damage )
    {
        var go = Instantiate(floatintextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = damage.ToString();
    }

    public void playSound(int index)
    {
        gameObject.GetComponent<AudioSource>().time = 0;
        
        switch (index)
        {
            case 0:
                gameObject.GetComponent<AudioSource>().clip = somDeAndar;
                gameObject.GetComponent<AudioSource>().time = 2;
            break;
            case 1:
                gameObject.GetComponent<AudioSource>().clip = somDeAtaque;
                break;
            case 2:
                gameObject.GetComponent<AudioSource>().time = 0;
                gameObject.GetComponent<AudioSource>().clip = somDeTomarDano;
            break;
            case 3:
                gameObject.GetComponent<AudioSource>().clip = somDeMorte;
            break;
        }
        
        if(!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            stopSound();
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
    
    public void stopSound()
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }
}
