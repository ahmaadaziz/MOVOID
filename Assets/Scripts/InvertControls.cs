using UnityEngine;
public class InvertControls : MonoBehaviour
{
    Cube cube;
    private void Start() 
    {
        cube = GameObject.Find("Player Cube").GetComponent<Cube>();    
    }
    private void OnTriggerEnter(Collider other) 
    {
        cube.isInverted = true;
        Destroy(gameObject);   
    }
}
