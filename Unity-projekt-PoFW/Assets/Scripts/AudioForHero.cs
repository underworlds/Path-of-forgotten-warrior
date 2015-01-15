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
    public AudioClip HearthBeating;

    public AudioSource AudioSourcePointer;
    private bool standing;
    private int stateOfKeys;
    
	// Use this for initialization
	void Start () {

        standing = false;
        stateOfKeys = 0;
        
	}
	//-opravit detekovanie ked su stiknute viac nez dve klavesy
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {

            if (stateOfKeys > 1)
            {

                if (Input.GetKey(KeyCode.A) && AudioSourcePointer.clip != SwordAudio)
                {
                    Debug.Log("A");
                    AudioSourcePointer.clip = SwordAudio;
                    AudioSourcePointer.volume = 1f;
                    AudioSourcePointer.Play();
                    standing = false;

                }
                if (Input.GetKey(KeyCode.S) && AudioSourcePointer.clip != ShieldAudio)
                {
                    Debug.Log("S");
                    AudioSourcePointer.clip = ShieldAudio;
                    AudioSourcePointer.volume = 1f;
                    AudioSourcePointer.Play();
                    standing = false;

                }
                if (Input.GetKey(KeyCode.D) && AudioSourcePointer.clip != SpearAudio)
                {
                    AudioSourcePointer.clip = SpearAudio;
                    AudioSourcePointer.volume = 1f;
                    AudioSourcePointer.Play();
                    standing = false;

                }
                if (Input.GetKey(KeyCode.LeftArrow) && AudioSourcePointer.clip != RunningAudio)
                {
                    AudioSourcePointer.clip = RunningAudio;
                    AudioSourcePointer.volume = 1f;
                    AudioSourcePointer.Play();
                    standing = false;

                }
                if (Input.GetKey(KeyCode.RightArrow) && AudioSourcePointer.clip != RunningAudio)
                {
                    AudioSourcePointer.clip = RunningAudio;
                    AudioSourcePointer.volume = 1f;
                    AudioSourcePointer.Play();
                    standing = false;

                }
                if (Input.GetKey(KeyCode.UpArrow) && AudioSourcePointer.clip != JumpAudio)
                {
                    AudioSourcePointer.clip = JumpAudio;
                    AudioSourcePointer.volume = 1f;
                    AudioSourcePointer.Play();
                    standing = false;

                }

            }
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AudioSourcePointer.clip = SwordAudio;
                stateOfKeys++;
                AudioSourcePointer.volume = 1f;
                AudioSourcePointer.Play();
                standing = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
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
            AudioSourcePointer.volume = 0.2f;
            AudioSourcePointer.Play();
            
        }
        
	}
}
