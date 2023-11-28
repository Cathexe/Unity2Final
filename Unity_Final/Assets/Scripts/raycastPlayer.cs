using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class raycastPlayer : MonoBehaviour
{
    public float raycastDistance = 5.0f;
    bool holdingItem = false;
    GameObject heldObj;

    public bool redBox = false;
    public bool blueBox = false;
    public bool purpleBox = false;
    public bool yellowBox = false;

    public GameObject doorButton;
    public Animator leftDoor;
    public Animator rightDoor;
    bool doorUnlocked = false;
    MeshRenderer hitOBJ;
    public GameObject messageBox;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward *raycastDistance, Color.yellow);

        if(redBox&&blueBox&&purpleBox&&yellowBox)
        {
            doorButton.GetComponent<Renderer>().material.color = Color.green;
            doorUnlocked = true;
        }
        else
        {
            doorButton.GetComponent<Renderer>().material.color = Color.red;
            doorUnlocked = false;
        }

        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, 3.0f)) 
        {
            if(hit.collider.tag == "PickupItem" && !holdingItem)
            {
                hitOBJ = hit.collider.GetComponent<MeshRenderer>();
                hitOBJ.materials[1].SetFloat("_Scale", 1.03f);
            }
            if(hit.collider.tag == "DoorButton" && doorUnlocked)
            {
                hitOBJ = hit.collider.GetComponent<MeshRenderer>();
                hitOBJ.materials[1].SetFloat("_Scale", 1.03f);
                messageBox.SetActive(true);
            }
        }
        else
        {
            if(hitOBJ != null) 
            {
                hitOBJ.materials[1].SetFloat("_Scale", 1.0f);
                hitOBJ = null;
                if(messageBox.activeSelf)
                {
                    messageBox.SetActive(false);
                }
            }
        }

    }

    public void PickupItem(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("PickupItem"))
                {
                   // hit.collider.GetComponent<PickupOBJ>().Pickup();
                    heldObj = hit.collider.gameObject;
                    holdingItem = true;

                }
               
            }
        }

        if(ctx.canceled)
        {
            if(holdingItem)
            {
                //heldObj.GetComponent<PickupOBJ>().Pickup();
                holdingItem = false;
                heldObj=null;
            }
        }
    }

    public void InteractableObj(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("DoorButton") && doorUnlocked)
                {
                    leftDoor.SetTrigger("OpenDoor");
                    rightDoor.SetTrigger("OpenDoor");
                }

            }
        }
    }
}
