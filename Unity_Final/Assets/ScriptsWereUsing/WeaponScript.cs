using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{

    public float weaponDamage = 10.0f;
    public float weaponRange = 50.0f;
    public float fireRate = 20.0f;
    public float nextfire = 0.0f;
    public Camera fpCamera;
    
    public void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(fpCamera.transform.position,fpCamera.transform.forward, out hit,weaponRange))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                Debug.Log(hit.collider.name);
                hit.collider.GetComponent<EnemyHealth>().TakeDamage(weaponDamage);
            }
            if (hit.transform.gameObject.tag == "Target")
            {
                Debug.Log(hit.collider.name);
                hit.transform.gameObject.GetComponent<blockscript>().platform();
            }
        }
    }

    public void Fireshot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && Time.time >=nextfire)
        {
            Debug.Log("fireshot");
            nextfire = 0;
            Shoot();
        }
    }

}
