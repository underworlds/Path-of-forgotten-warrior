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
    public bool timeToThrow;

    private Transform character;

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
        character = GameObject.FindGameObjectWithTag("Character").transform;
        timeToThrow = character.GetComponent<CharacterFighting>().isTimeToThrowSpear;
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
               
              /*  if (Input.GetKey(KeyCode.D) && AudioSourcePointer.clip != SpearAudio && timeToThrow)
                 {
                     
                     AudioSourcePointer.loop = false;
                     AudioSourcePointer.clip = SpearAudio;
                     AudioSourcePointer.volume = 1f;
                     AudioSourcePointer.Play();
                     standing = false;
                 }*/
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                AudioSourcePointer.loop = true;
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
           // Debug.Log(timeToThrow);
            if (Input.GetKeyDown(KeyCode.D) && timeToThrow)
            {
                Debug.Log("ItHappened");
                AudioSourcePointer.loop = false;
                AudioSourcePointer.clip = SpearAudio;
                stateOfKeys++;
                AudioSourcePointer.volume = 1f;
                AudioSourcePointer.Play();
                standing = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AudioSourcePointer.loop = true;
                AudioSourcePointer.clip = RunningAudio;
                stateOfKeys++;
                AudioSourcePointer.volume = 1f;
                AudioSourcePointer.Play();
                standing = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AudioSourcePointer.loop = true;
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
            if ((AudioSourcePointer.clip == ShieldAudio || AudioSourcePointer.clip == SpearAudio || AudioSourcePointer.clip == JumpAudio || AudioSourcePointer.clip == DyingAudio) && AudioSourcePointer.isPlaying)
            {

            }
            else
            {
                AudioSourcePointer.clip = HearthBeating;
                AudioSourcePointer.volume = 0f;
                AudioSourcePointer.Play();
            }
        }
        
	}
    public void deathSound()
    {
        AudioSourcePointer.clip = DyingAudio;
        AudioSourcePointer.volume = 1f;
        AudioSourcePointer.Play();
    }
}
