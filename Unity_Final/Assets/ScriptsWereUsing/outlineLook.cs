using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlineLook : MonoBehaviour
{
    public float raycastDistance = 5.0f;
    MeshRenderer hitobj;

    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward,out hit, 15.0f))
        {
            if(hit.collider.tag == "Target")
            {
                hitobj = hit.collider.GetComponent<MeshRenderer>();
                hitobj.materials[1].SetFloat("_Scale", 1.03f);
            }
        }
        else
        {
            if(hitobj!=null) 
            {
                hitobj.materials[1].SetFloat("_Scale", 1.0f);
                hitobj = null;
            }
        }
    }

}
