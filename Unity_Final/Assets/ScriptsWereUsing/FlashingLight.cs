using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    public bool lightOn = false;
    public float timeDelay;

    // Update is called once per frame
    void Update()
    {
        if (lightOn == false)
        {
            StartCoroutine(LightFlash());
        }
    }

    IEnumerator LightFlash()
    {
        lightOn = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = 2.0f;
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = 1.0f;
        yield return new WaitForSeconds(timeDelay);
        lightOn = false;
    }
}
