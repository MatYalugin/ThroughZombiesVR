using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class NukeLauncher : MonoBehaviour
{
    private Interactable interactable;
    private SteamVR_Action_Boolean fireAction;
    public GameObject miniNuke;
    public GameObject miniNukePrefab;
    public int launchNumber = 1;
    public Transform launchPoint;
    public AudioSource launchSound;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        fireAction = SteamVR_Actions.default_InteractUI;
    }

    // Update is called once per frame
    void Update()
    {
        if(launchNumber == 0)
        {
            miniNuke.SetActive(false);
        }
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            if (fireAction[hand].stateDown && launchNumber != 0)
            {
                LaunchMiniNuke();
                launchNumber -= 1;
            }
        }
    }

    public void LaunchMiniNuke()
    {

        GameObject grenade = Instantiate(miniNukePrefab, launchPoint.position, launchPoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        // Вычисляем направление броска под определенным углом вверх
        Vector3 throwDirection = Quaternion.AngleAxis(30, -transform.right) * launchPoint.transform.forward;

        // Добавляем импульсную силу в заданном направлении
        rb.AddForce(throwDirection * 35, ForceMode.Impulse);
        launchSound.Play();
    }
}
