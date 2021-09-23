using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audios;
    public AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!BGM.isPlaying)
        {
            BGM.clip = audios[0];
            BGM.Play();
        }
    }
}
