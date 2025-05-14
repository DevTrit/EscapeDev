using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typing : MonoBehaviour
{

    public AudioSource typing;

    public GameObject Final;

    public bool Last;

    public AudioSource LastSong;
    public AudioSource BackgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        Last = true;
        typing.Play();
        BackgroundMusic.Play();
        Invoke("Stop", 22.5f);
    }

    private void Stop()
    {
        typing.Stop();
    }

    private void EndingStop()
    {
        typing.Stop();
        Invoke("EndingStart", 1.5f);
    }

    void Update()
    {
        bool LastStory = Final.GetComponent<Ending>().LastStory;
        if(Last == true && LastStory == true)
        {
            Last = false;
            typing.Play();
            Invoke("EndingStop", 7);
        }
    }

    private void EndingStart()
    {
        typing.Play();
        Invoke("Last1", 13);
    }

    private void Last1()
    {
        BackgroundMusic.Stop();
        LastSong.Play();
    }
}
