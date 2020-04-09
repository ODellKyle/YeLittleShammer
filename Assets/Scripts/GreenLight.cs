using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLight : MonoBehaviour
{
    public AudioClip active;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = active;
        audio.Play();
    }
}
