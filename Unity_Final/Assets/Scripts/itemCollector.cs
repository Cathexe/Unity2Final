using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class itemCollector : MonoBehaviour
{
    public int itemsCollected, itemInLevel;
    public TMP_Text itemHUD;
    // Start is called before the first frame update
    void Start()
    {
        itemHUD.text = $"Mushrooms:{itemsCollected}/{itemInLevel}";
    }

    public void itemCollect()
    {
        itemsCollected++;
        itemHUD.text = $"Mushrooms:{itemsCollected}/{itemInLevel}";

        if (itemsCollected >= itemInLevel)
        {
            //change scene
            StartCoroutine(GameOver());

        }
    }

    IEnumerator GameOver()
    {
        itemHUD.text = $"You collected all the Mushrooms!";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
