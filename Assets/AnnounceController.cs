using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;//remove this when youre done testing
using UnityEngine;


public class AnnounceController : MonoBehaviour
{
    public Text announcementMessage;

    public string testMessage = "test test test test testtest test test test testtest test test test test\\";
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
    //fix it! this does not work at all, only for demonstration
    void AddLetter()
    {
        if (testIndex < testMessage.Length)
        {
            testIndex++;
            announcementMessage.text += testMessage[testIndex];
        }
        else
            announcementMessage.text += "! ";
    }
}
