using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownController : MonoBehaviour
{
    public Image countdownImage;
    public Sprite redLight;
    public Sprite yellowLight;
    public Sprite greenLight;
    public float interval = 1f;

    private void Start()
    {
        StartCoroutine(CountdownSequence());
    }

    private IEnumerator CountdownSequence()
    {
        countdownImage.sprite = redLight;
        yield return new WaitForSeconds(interval);
        countdownImage.sprite = yellowLight;
        yield return new WaitForSeconds(interval);
        countdownImage.sprite = greenLight;
        yield return new WaitForSeconds(interval);
        countdownImage.enabled = false;

        // Start the race timer and enable the player's car controls here
    }
}