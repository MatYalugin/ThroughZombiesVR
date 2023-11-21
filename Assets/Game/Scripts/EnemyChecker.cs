using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public Animator lockedFoorAnimator;
    private bool doorOpened;
    private void Start()
    {

    }
    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0 && doorOpened == false)
        {
            lockedFoorAnimator.Play("Open");
            doorOpened = true;
        }
    }
}

