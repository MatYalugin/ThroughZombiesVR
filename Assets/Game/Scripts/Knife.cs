using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Knife : MonoBehaviour
{
    private Interactable interactable;
    public float knifeDamage;
    public GameObject knife;
    public Collider bladeCollider;
    public AudioSource kickSound;
    // Start is called before the first frame update
    public void Start()
    {
        interactable = knife.GetComponent<Interactable>();
    }


    // Update is called once per frame
    public void Update()
    {
        if (interactable.attachedToHand == null)
        {
            bladeCollider.enabled = false;
        }
        else
        {
            bladeCollider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Target"))
        {
            other.gameObject.SendMessage("ApplyDamage", SendMessageOptions.DontRequireReceiver);
            kickSound.Play();
        }
        if (other.tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().takeDamage(knifeDamage);
            kickSound.Play();
        }
    }
}
