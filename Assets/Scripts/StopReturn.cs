using UnityEngine;
public class StopReturn : MonoBehaviour
{
    private BoxCollider boxCollider;
    private void Start() 
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }
    private void OnTriggerExit(Collider other) 
    {
        boxCollider.isTrigger = false;
    }
}
