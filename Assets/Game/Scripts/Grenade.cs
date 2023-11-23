using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Grenade : MonoBehaviour
{
    private Interactable interactable;
    private SteamVR_Action_Boolean fireAction;
    public FixedJoint bodyFixedJoint;
    public GameObject pin;
    public GameObject lever;
    private bool hasExploded;
    private bool pinSoundPlayed;
    public AudioSource pinPullSound;
    //Explosion
    public AudioSource explosionSound;
    public ParticleSystem explosionEffect;
    public GameObject damageSphere;
    public GameObject grenadeBase;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        fireAction = SteamVR_Actions.default_InteractUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            if (fireAction[hand].stateDown)
            {
                Destroy(bodyFixedJoint);
                pin.SetActive(false);
                if (!pinSoundPlayed)
                {
                    pinPullSound.Play();
                    pinSoundPlayed = true;
                }
            }
        }
        if (interactable.attachedToHand == null && pin.activeSelf == false)
        {
            lever.SetActive(false);
            if (!hasExploded)
            {
                Invoke("explode", 3.4f);
                hasExploded = true;
            }
        }
    }
    public void explode()
    {
        grenadeBase.SetActive(false);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        explosionSound.Play();
        explosionEffect.Play();
        damageSphere.SetActive(true);
        Invoke("removeDamageSphere", 0.02f);
        Invoke("destroySelf", 3f);
    }
    public void removeDamageSphere()
    {
        Destroy(damageSphere);
    }
    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
