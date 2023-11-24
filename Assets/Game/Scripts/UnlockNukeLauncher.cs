using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNukeLauncher : MonoBehaviour
{
    public GameObject nukeLauncher;
    public void Unlock()
    {
        nukeLauncher.SetActive(true);
    }
}
