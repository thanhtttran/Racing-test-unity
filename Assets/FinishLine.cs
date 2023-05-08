using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject player;
    public GameObject raceManager;

    private void OnTriggerEnter(Collider other)
{
    Debug.Log("Trigger entered: " + other.gameObject.name + " at position: " + other.gameObject.transform.position);
    Debug.Log("Finish line position: " + transform.position);

    if (other.gameObject.CompareTag("PlayerCar"))
    {
        Debug.Log("Player crossed the finish line at position: " + other.gameObject.transform.position);
        raceManager.GetComponent<RaceManager>().FinishRace();
    }
}




}