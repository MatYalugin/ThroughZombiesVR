using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }
}
