using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupOBJ : MonoBehaviour
{
    bool pickUp = false;
    Rigidbody rb;
    public Transform destinationOBJ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pickup()
    {
        pickUp = !pickUp;

        if (pickUp)
        {
            rb.useGravity = false;
            rb.isKinematic = true;

            transform.position = destinationOBJ.position;
            transform.parent = destinationOBJ.transform;
        }
        else
        {
            rb.useGravity = true;
            rb.isKinematic = false;

            transform.parent = null;
        }
    }
}
