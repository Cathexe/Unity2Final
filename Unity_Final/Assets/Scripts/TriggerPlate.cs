using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour
{
    public raycastPlayer raycastScript;
    [SerializeField]
    string objTag;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == objTag)
        {
            if (other.gameObject.name == "RedBox")
            {
                raycastScript.redBox = true;
            }
            if (other.gameObject.name == "BlueBox")
            {
                raycastScript.blueBox = true;
            }
            if (other.gameObject.name == "PurpleBox")
            {
                raycastScript.purpleBox = true;
            }
            if (other.gameObject.name == "YellowBox")
            {
                raycastScript.yellowBox = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == objTag)
        {
            if (other.gameObject.name == "RedBox")
            {
                raycastScript.redBox = false;
            }
            if (other.gameObject.name == "BlueBox")
            {
                raycastScript.blueBox = false;
            }
            if (other.gameObject.name == "PurpleBox")
            {
                raycastScript.purpleBox = false;
            }
            if (other.gameObject.name == "YellowBox")
            {
                raycastScript.yellowBox = false;
            }
        }
    }


}
