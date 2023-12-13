using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pickup : MonoBehaviour
{
    itemCollector collector;
    public bool isLocked = true;

    // Start is called before the first frame update
    void Start()
    {
        collector = GameObject.Find("Door").GetComponent<itemCollector>();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(0, 1, 0);
        
   
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            collector.itemCollect();
            Destroy(gameObject);
        }
    }
}

