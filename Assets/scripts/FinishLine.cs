using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//remove this when youre done testing

public class FinishLine : MonoBehaviour
{
    public GameObject player;
    public GameObject raceManager;
    public int lapsAmount = 2;
    private int lapCount = 0;

    public Text UIlapCount;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger entered: " + other.gameObject.name + " at position: " + other.gameObject.transform.position);
        //Debug.Log("Finish line position: " + transform.position);

        if (other.gameObject.CompareTag("PlayerCar"))
        {
            Debug.Log("Player crossed the finish line at position: " + other.gameObject.transform.position);
            lapCount++;
            UIlapCount.text = lapCount.ToString() + " / " + lapsAmount.ToString();
            if (lapCount == lapsAmount)
            {
                raceManager.GetComponent<RaceManager>().FinishRace();
            }
        }
    }




}