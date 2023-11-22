using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public List<GameObject> weapons;
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
            playerDied();
        }
    }
    public void playerDied()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        foreach (GameObject obj in weapons)
        {
            Destroy(obj);
        }
    }
}
