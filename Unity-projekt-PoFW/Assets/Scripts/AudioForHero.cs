using UnityEngine;
using System.Collections;

public class AudioForHero : MonoBehaviour {

    public AudioClip RunningAudio;
    public AudioClip DyingAudio;
    public AudioClip GameMenuAudio;
    public AudioClip JumpAudio;
    public AudioClip ShieldAudio;
    public AudioClip SpearAudio;
    public AudioClip SwordAudio;

    public AudioSource AudioSourcePointer;
	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AudioSourcePointer.clip = SwordAudio;
                AudioSourcePointer.Play();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                AudioSourcePointer.clip = ShieldAudio;
                AudioSourcePointer.Play();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                AudioSourcePointer.clip = SpearAudio;
                AudioSourcePointer.Play();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AudioSourcePointer.clip = RunningAudio;
                AudioSourcePointer.Play();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AudioSourcePointer.clip = RunningAudio;
                AudioSourcePointer.Play();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AudioSourcePointer.clip = JumpAudio;
                AudioSourcePointer.Play();
            }
        }
        
        
	}
}
