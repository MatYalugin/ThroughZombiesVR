using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class AidKit : MonoBehaviour
{
    private GameObject player;
    private Interactable interactable;
    private SteamVR_Action_Boolean fireAction;
    public int healthToGivePlayer = 40;
    public int amountOfUses = 3;
    public Text usesText;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        fireAction = SteamVR_Actions.default_InteractUI;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        usesText.text = "Uses: " + amountOfUses;
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            if (fireAction[hand].stateDown && amountOfUses != 0 && player.GetComponent<PlayerHealth>().health != 100)
            {
                amountOfUses -= 1;
                player = GameObject.Find("Player");
                player.GetComponent<PlayerHealth>().takeHealth(healthToGivePlayer);
            }
        }
        if (amountOfUses == 0)
        {
            Destroy(gameObject);
        }
    }
}
