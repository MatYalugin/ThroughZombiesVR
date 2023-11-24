using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniNukeExplosion : MonoBehaviour
{
    public GameObject explosionEffectPrefab;
    public AudioSource explosionSound;
    private bool isReadyToExplode;
    public GameObject damageSphere;
    public GameObject whistlingSound;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("makeReadyToExplode", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != null && isReadyToExplode == true)
        {
            damageSphere.SetActive(true);
            Invoke("removeDamageSphere", 0.02f);
            Destroy(whistlingSound);
            GameObject newExplosionEffect = Instantiate(explosionEffectPrefab, gameObject.transform.position, Quaternion.identity);
            explosionSound.Play();
            gameObject.GetComponent<MeshCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Invoke("destroySelf", 15f);
        }
    }
    public void removeDamageSphere()
    {
        Destroy(damageSphere);
    }
    public void makeReadyToExplode()
    {
        isReadyToExplode = true;
    }
    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
