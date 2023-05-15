using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;//remove this when youre done testing
using UnityEngine;



public class AnnounceController : MonoBehaviour
{
    public Text announcementMessage;

    public AudioSource audioHandler;
    public AudioClip dialogueSound;
    public AudioClip yellSound;

    public float dialogueVol = 0.5f;
    public float dialoguePitch = 1.5f;

    public string Message = "dummy message\\";
    int testIndex = 0;

    //private bool isTyping = false;
    private void Start()
    {
        audioHandler.volume = dialogueVol;
        audioHandler.pitch = dialoguePitch;
    }
    private void AddLetter()
    {
        if (testIndex < Message.Length)
        {
            if(!audioHandler.isPlaying) { 
            audioHandler.PlayOneShot(dialogueSound);
            }
            announcementMessage.text += Message[testIndex];
            testIndex++;
        }
    }

    public void typeMessage(string newMessage)
    {
        //Debug.Log("playing new message: " + newMessage);
        Message = newMessage;
        CancelInvoke();

        //reset the announcement
        testIndex = 0;
        announcementMessage.text = "";
        InvokeRepeating("AddLetter", 0.0f, 0.05f);
    }

    public void typeMessageInstant(string newMessage)
    {
        Message = newMessage;
        CancelInvoke();
        //reset the announcement
        if (!audioHandler.isPlaying)
        {
            audioHandler.PlayOneShot(yellSound);
        }
        testIndex = 0;
        announcementMessage.text = newMessage;
    }
}
