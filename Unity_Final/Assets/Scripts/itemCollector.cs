using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class itemCollector : MonoBehaviour
{
    bool stop = false;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume;
    public bool isLocked = true;
    public int itemsCollected, itemInLevel;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (itemsCollected == 3)
        {
            isLocked = false;
            if(stop == false)
            {
                audioSource.PlayOneShot(clip, volume);
                stop = true;
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.CompareTag("Player")) && (isLocked == false))
        {
            SceneManager.LoadScene(1);
        }
    }
    public void itemCollect()
    {
        itemsCollected++;

    }


}
