using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class IpodClick : MonoBehaviour {

    public struct Song
    {
        public string Title;
        public string Band;
    }

    LinkedList<Song> songs;
    LinkedListNode<Song> current;
    bool playing;

    public GameObject text;
    public GameObject play;
    public GameObject stop;

    GameObject song;

	// Use this for initialization
	void Start () {
        playing = false;
        songs = new LinkedList<Song>();

        Song temp;
        temp.Title = "Burning Down the Nicotine Armoire";
        temp.Band = "Dance Gavin Dance";
        songs.AddLast(temp);

        temp.Title = "Happiness";
        //temp.Band = "Band2";
        songs.AddLast(temp);

        temp.Title = "Open Your Eyes and Look North";
        //temp.Band = "Band3";
        songs.AddLast(temp);

        current = songs.First;
        text.GetComponent<Text>().text = current.Value.Title + "\n" + current.Value.Band;
        stop.GetComponent<SpriteRenderer>().enabled = true;
        song = GameObject.Find(current.Value.Title);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Previous()
    {
        song.GetComponent<AudioSource>().Stop();
        if (current.Previous != null)
        {
            current = current.Previous;
            Debug.Log(current.Value.Title);
            Debug.Log(current.Value.Band);
            text.GetComponent<Text>().text = current.Value.Title + "\n" + current.Value.Band;
            song = GameObject.Find(current.Value.Title);
            playing = true;
            Play();
        }

        else
            Debug.Log("beginning of list");
    }

    public void Next()
    {
        song.GetComponent<AudioSource>().Stop();
        if (current.Next != null)
        {
            current = current.Next;
            Debug.Log(current.Value.Title);
            Debug.Log(current.Value.Band);
            text.GetComponent<Text>().text = current.Value.Title + "\n" + current.Value.Band;
            song = GameObject.Find(current.Value.Title);
            playing = true;
            Play();
        }

        else
            Debug.Log("end of list");
    }

    public void Menu()
    {
        Debug.Log("Menu");
    }

    public void Play()
    {
        if (playing)
        {
            song.GetComponent<AudioSource>().Stop();
            Debug.Log("Pause");
            playing = false;
            stop.GetComponent<SpriteRenderer>().enabled = true;
            play.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            song.GetComponent<AudioSource>().Play();
            Debug.Log("Play");
            Debug.Log(current.Value.Title);
            Debug.Log(current.Value.Band);
            playing = true;
            stop.GetComponent<SpriteRenderer>().enabled = false;
            play.GetComponent<SpriteRenderer>().enabled = true;
        }

    }
}
