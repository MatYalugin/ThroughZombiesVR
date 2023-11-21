using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    public void spawnZombie()
    {
        Instantiate(zombiePrefab, transform.position, transform.rotation);
    }
}
