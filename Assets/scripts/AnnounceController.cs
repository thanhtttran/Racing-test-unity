using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;//remove this when youre done testing
using UnityEngine;


public class AnnounceController : MonoBehaviour
{
    public Text announcementMessage;

    public string Message = "dummy message\\";
    int testIndex = 0;

    //maybe move the loop / array string thingy to somewhere else instead (refactor)
    //out of bound once everytime, why
    private void AddLetter()
    {
        if (testIndex < Message.Length)
        {
            announcementMessage.text += Message[testIndex];
            testIndex++;
        }
    }

    public void typeMessage(string newMessage)
    {
        Debug.Log("playing new message: " + newMessage);
        Message = newMessage;
        CancelInvoke();

        //reset the announcement, this is so ugly...
        testIndex = 0;
        announcementMessage.text = "";
        InvokeRepeating("AddLetter", 0.0f, 0.05f);
    }
}
