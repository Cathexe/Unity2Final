using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupOBJ : MonoBehaviour
{
    public int items = 3;
    public Animator frontdoor;
    public bool OpenDoor = false;

    public void pickups()
    {
        if (items == 0)
        {
            OpenDoor = true;
        }
    }
    
}
