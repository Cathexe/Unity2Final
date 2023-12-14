using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class raycastPlayer : MonoBehaviour
{
    public float raycastDistance = 5.0f;
    bool holdingItem = false;
    GameObject heldObj;

    public bool item1 = false;
    public bool item2 = false;
    public bool item3 = false;
    public bool item4 = false;

    public Animator door;
    bool doorUnlocked = false;
    MeshRenderer hitOBJ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward *raycastDistance, Color.yellow);

        if(item1 && item2 && item3 && item4)
        {
            doorUnlocked = true;
        }
        else
        {
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
            if(doorUnlocked)
            {
                hitOBJ = hit.collider.GetComponent<MeshRenderer>();
                hitOBJ.materials[1].SetFloat("_Scale", 1.03f);
            }
        }
        else
        {
            if(hitOBJ != null) 
            {
                hitOBJ.materials[1].SetFloat("_Scale", 1.0f);
                hitOBJ = null;
                
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
                if (hit.collider.CompareTag("pickupItem"))
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
                if (doorUnlocked)
                {
                    door.SetTrigger("OpenDoor");
                }

            }
        }
    }
}
