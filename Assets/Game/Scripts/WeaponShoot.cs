using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class WeaponShoot : MonoBehaviour
{
    private Interactable interactable;
    private SteamVR_Action_Boolean fireAction;
    public Transform barrel;
    public AudioSource shotSound;
    public ParticleSystem muzzleFlash;
    public ParticleSystem catridgeEffect;
    private bool isReadyToFire = true;
    public float weaponCoolDown;
    public float distance = 50;
    public float weaponDamage;
    public bool autoFire;
    public Animator weaponAnimator;
    private GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        interactable = GetComponent<Interactable>();
        fireAction = SteamVR_Actions.default_InteractUI;
        weaponAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            if (fireAction[hand].stateDown && isReadyToFire == true)
            {
                Fire();
            }
            if (fireAction[hand].state && isReadyToFire == true && autoFire == true)
            {
                Fire();
            }
        }
    }
    private void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, distance))
        {
            if(Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Target"))
                {
                    hit.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
                }
                if (hit.transform.tag.Equals("Enemy"))
                {
                    hit.collider.gameObject.GetComponent<Enemy>().takeDamage(weaponDamage);
                }
                if (hit.transform.tag.Equals("Head"))
                {
                    player = GameObject.Find("Player");
                    player.gameObject.GetComponent<PlayerHealth>().takeDamage(100);
                }
            }
        }
        muzzleFlash.Play();
        catridgeEffect.Play();
        shotSound.Play();
        weaponAnimator.Play("Shot");
        isReadyToFire = false;
        Invoke("makeReadyToFire", weaponCoolDown);
    }
    private void makeReadyToFire()
    {
        isReadyToFire = true;
    }
}
