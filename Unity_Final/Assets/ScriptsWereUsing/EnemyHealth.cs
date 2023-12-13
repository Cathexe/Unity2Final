using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image healthbar;
    public GameObject healthBarobj;
    public float enemyhealth = 100;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyhealth;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth >= 0)
        {
            currentHealth -= damage;
            healthbar.fillAmount = currentHealth / enemyhealth;
        }
        if (currentHealth <= 0)
        {
            //enemy dead
            dead();
        }
    }

    void dead()
    {
        Destroy(healthBarobj);
        Destroy(gameObject);
    }

}

