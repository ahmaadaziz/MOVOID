using UnityEngine;

public class WhenToDissolve : MonoBehaviour
{
    public bool shouldDissolve = false;
    private void OnTriggerEnter(Collider other) 
    {
        shouldDissolve = true;
    }
}
