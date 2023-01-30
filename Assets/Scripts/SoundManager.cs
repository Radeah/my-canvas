using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip SprayPaintSound, SkateBoardJumpSound, SkateBoardingSound, MyCanvasPoemSound, CrowdedAreaSound;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        SprayPaintSound = Resources.Load<AudioClip>("SprayPaint");
        SkateBoardJumpSound = Resources.Load<AudioClip>("SkateBoardJumping");
        SkateBoardingSound = Resources.Load<AudioClip>("SkateBoardJumping");
        MyCanvasPoemSound = Resources.Load<AudioClip>("MyCanvasPoem");
        CrowdedAreaSound = Resources.Load<AudioClip>("CrowdedArea");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update() { 
    

    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {

        }
    }




}


