using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;


public class Pickup : MonoBehaviour
{
    public int items = 3;
    itemCollector collector;
    public bool OpenDoor;

    // Start is called before the first frame update
    void Start()
    {
        //collector = GameObject.Find("CoinHUD").GetComponent<itemCollector>();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(0, 1, 0);
        
        if (items == 0)
        {
            OpenDoor = true;
        }
        else
        {
            OpenDoor = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            items--;
        }
    }
}
