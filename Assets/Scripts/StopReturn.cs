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
        if (transform.parent.name == "Level 0(Clone)")
        {
            boxCollider.isTrigger = false;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        boxCollider.isTrigger = false;
    }
}
