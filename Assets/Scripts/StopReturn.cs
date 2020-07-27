using UnityEngine;
public class StopReturn : MonoBehaviour
{
    public BoxCollider boxCollider;
    private void Start() 
    {
        if (boxCollider.isTrigger == false)
        {
            boxCollider.isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        boxCollider.isTrigger = false;
    }
}
