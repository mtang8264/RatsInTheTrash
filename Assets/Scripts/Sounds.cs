using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip mainTheme;
    public AudioClip splash;
    public AudioClip reel;

    AudioSource music;
    AudioSource fx;

    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.Find("Sound").GetComponent<AudioSource>();
        fx = GameObject.Find("FX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fx.clip == splash && fx.isPlaying == false)
        {
            fx.clip = reel;
            fx.Play();
        }
    }

    public void GoToBeach()
    {
        fx.clip = splash;
        fx.Play();
    }
}
