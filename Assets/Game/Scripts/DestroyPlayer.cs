using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }
    public void destroyPlayer()
    {
        player.GetComponent<PlayerHealth>().playerDied();
    }
}
