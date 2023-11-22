using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class GoToMainMenu : MonoBehaviour
{
    private Interactable interactable;
    private SteamVR_Action_Boolean fireAction;
    public GameObject playerGO;
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
                playerGO.GetComponent<PlayerHealth>().playerDied();
            }
        }
    }
}
