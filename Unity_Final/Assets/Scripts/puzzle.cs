using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class puzzle : MonoBehaviour
{

    bool first = false;
    bool second = false;
    bool third = false;
    bool fourth = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "1")
        {
            if (other.gameObject.name == "box1")
            {
                first = true;
            }
        }

        if (other.gameObject.name == "2")
        {
            if (other.gameObject.name == "box2")
            {
                second = true;
            }
        }
        if (other.gameObject.name == "3")
        {
            if (other.gameObject.name == "box3")
            {
                third = true;
            }
        }
        if (other.gameObject.name == "4")
        {
            if (other.gameObject.name == "box4")
            {
                fourth = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "1")
        {
            if (other.gameObject.name == "box1")
            {
                first = false;
            }
        }
        if (other.gameObject.name == "2")
        {
            if (other.gameObject.name == "box2")
            {
                second = false;
            }
        }
        if (other.gameObject.name == "3")
        {
            if (other.gameObject.name == "box3")
            {
                third = false;
            }
        }
        if (other.gameObject.name == "4")
        {
            if (other.gameObject.name == "box4")
            {
                fourth = false;
            }
        }
    }

    void Update()
    {
        if (first == true && second == true && third == true && fourth == true)
        {
            // Open door hopefully?
        }
    }
}