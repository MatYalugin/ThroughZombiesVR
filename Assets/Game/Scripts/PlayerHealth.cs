using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public Slider HealthBar;
    public Text HealthText;
    public List<GameObject> weapons;
    private GameObject nukeLauncher;
    // Start is called before the first frame update
    void Start()
    {
        nukeLauncher = GameObject.Find("FalloutNukeLauncher");
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBar != null)
        {
            HealthBar.value = health;
            HealthText.text = "" + health;
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            playerDied();
        }
    }
    public void takeHealth(float Health)
    {
        health += Health;
        if (health > 100)
        {
            health = 100;
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
        Destroy(nukeLauncher);
    }
}
