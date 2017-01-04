using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour
{

    public Object[] soundtrack;   //list of all audio tracks to be looped through randomly
    
    void Awake()
    {
        //initialise soundtrack
        soundtrack = Resources.LoadAll("Music", typeof(AudioClip));
        //initialise starting song
        GetComponent<AudioSource>().clip = soundtrack[Random.Range(0, soundtrack.Length)] as AudioClip;
    }

	// Use this for initialization
	void Start ()
    {
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //check if no song is playing
        if (!GetComponent<AudioSource>().isPlaying)
        {
            NextSong();
        }
	}

    void NextSong()
    {
        //get the next song to play
        GetComponent<AudioSource>().clip = soundtrack[Random.Range(0, soundtrack.Length)] as AudioClip;
        GetComponent<AudioSource>().Play();
    }
}
