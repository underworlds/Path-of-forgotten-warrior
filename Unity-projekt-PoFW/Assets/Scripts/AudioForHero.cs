using UnityEngine;
using System.Collections;

public class AudioForHero : MonoBehaviour {

    public AudioClip RunningAudio;
    public AudioClip DyingAudio;
    public AudioClip JumpAudio;
    public AudioClip ShieldAudio;
    public AudioClip SpearAudio;
    public AudioClip SwordAudio;
    public AudioClip HearthBeating;

    public AudioSource AudioSourcePointer;
    private bool standing;
    private int stateOfKeys;
    
	// Use this for initialization
	void Start () {

        standing = false;
        stateOfKeys = 0;
        AudioSourcePointer.clip = HearthBeating;
        AudioSourcePointer.volume = 0f;
        AudioSourcePointer.Play();
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(AudioSourcePointer.clip.name);
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {

            if (stateOfKeys > 1)
            {

                if (Input.GetKey(KeyCode.A) && AudioSourcePointer.clip != SwordAudio)
                {
                    AudioSourcePointer.loop = true;
                    AudioSourcePointer.clip = SwordAudio;
                    AudioSourcePointer.volume = 1f;
                    AudioSourcePointer.Play();
                    standing = false;
                }
                if (Input.GetKey(KeyCode.D) && AudioSourcePointer.clip != SpearAudio)
                {
                    AudioSourcePointer.loop = true;
                    AudioSourcePointer.clip = SpearAudio;
                    AudioSourcePointer.volume = 1f;
                    AudioSourcePointer.Play();
                    standing = false;
                }
                if (Input.GetKey(KeyCode.LeftArrow) && AudioSourcePointer.clip != RunningAudio)
                {
                    AudioSourcePointer.loop = true;
                    AudioSourcePointer.clip = RunningAudio;
                    AudioSourcePointer.volume = 1f;
                    AudioSourcePointer.Play();
                    standing = false;
                }
                if (Input.GetKey(KeyCode.RightArrow) && AudioSourcePointer.clip != RunningAudio)
                {
                    AudioSourcePointer.loop = true;
                    AudioSourcePointer.clip = RunningAudio;
                    AudioSourcePointer.volume = 1f;
                    AudioSourcePointer.Play();
                    standing = false;
                }
            }
        }

        if (Input.anyKeyDown)
        {
            AudioSourcePointer.loop = true;
            if (Input.GetKeyDown(KeyCode.A))
            {
                
                AudioSourcePointer.clip = SwordAudio;
                stateOfKeys++;
                AudioSourcePointer.volume = 1f;
                AudioSourcePointer.Play();
                standing = false;
            }
            if (Input.GetKeyDown(KeyCode.S) && stateOfKeys == 0)
            {
                AudioSourcePointer.loop = false;
                AudioSourcePointer.clip = ShieldAudio;
                stateOfKeys++;
                AudioSourcePointer.volume = 1f;
                AudioSourcePointer.Play();
                standing = false;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                
                AudioSourcePointer.clip = SpearAudio;
                stateOfKeys++;
                AudioSourcePointer.volume = 1f;
                AudioSourcePointer.Play();
                standing = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                
                AudioSourcePointer.clip = RunningAudio;
                stateOfKeys++;
                AudioSourcePointer.volume = 1f;
                AudioSourcePointer.Play();
                standing = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                
                AudioSourcePointer.clip = RunningAudio;
                stateOfKeys++;
                AudioSourcePointer.volume = 1f;
                AudioSourcePointer.Play();
                standing = false;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AudioSourcePointer.loop = false;
                AudioSourcePointer.clip = JumpAudio;
                stateOfKeys++;
                AudioSourcePointer.volume = 1f;
                AudioSourcePointer.Play();
                standing = false;
            }
        }

        if (!Input.anyKey && !standing)
        {
            stateOfKeys = 0;
            standing = true;

            AudioSourcePointer.clip = HearthBeating;
            AudioSourcePointer.volume = 0f;
            AudioSourcePointer.Play();

        }
        
	}

}
