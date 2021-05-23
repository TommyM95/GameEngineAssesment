using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource backgroundMusic1;
    public AudioSource backgroundMusic2;
    public bool playOneOrTwo;

    private void Start()
    {
        if (playOneOrTwo == true)
        {
            backgroundMusic1.Play();
        }
        else if (playOneOrTwo != true)
        {
            if (backgroundMusic2 != null)
            {
                backgroundMusic2.Play();
            }
            else
            {
                return;
            }
            
        }
    }
}
