using UnityEngine;
public class InvertControls : MonoBehaviour
{
    GameObject cubeObj;
    Cube cube;
    private void Start() 
    {
        cubeObj = GameObject.Find("Player Cube");
        cube = cubeObj.GetComponent<Cube>();    
    }
    private void OnTriggerEnter(Collider other) 
    {
        cube.isInverted = true;
        Destroy(gameObject);   
    }
}
