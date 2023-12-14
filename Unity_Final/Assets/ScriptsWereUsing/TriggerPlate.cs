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
            if (other.gameObject.name == "item1")
            {
                raycastScript.item1 = true;
            }
            if (other.gameObject.name == "item2")
            {
                raycastScript.item2 = true;
            }
            if (other.gameObject.name == "item3")
            {
                raycastScript.item3 = true;
            }
            if (other.gameObject.name == "item4")
            {
                raycastScript.item4 = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == objTag)
        {
            if (other.gameObject.name == "item1")
            {
                raycastScript.item1 = false;
            }
            if (other.gameObject.name == "item2")
            {
                raycastScript.item2 = false;
            }
            if (other.gameObject.name == "item3")
            {
                raycastScript.item3 = false;
            }
            if (other.gameObject.name == "item4")
            {
                raycastScript.item4 = false;
            }
        }
    }


}
