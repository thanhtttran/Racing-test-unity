using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;//remove this when youre done testing
using UnityEngine;


public class AnnounceController : MonoBehaviour
{
    public Text announcementMessage;

    public string testMessage = "dummy message\\";
    int testIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddLetter", 0.0f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //maybe move the loop / array string thingy to somewhere else instead (refactor)
    //out of bound once everytime, why
    void AddLetter()
    {
        if (testIndex < testMessage.Length)
        {
            announcementMessage.text += testMessage[testIndex];
            testIndex++;
        }
        //else
            //announcementMessage.text += "! ";
    }
}
