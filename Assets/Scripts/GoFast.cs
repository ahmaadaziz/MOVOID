using UnityEngine;
using System.Collections;

public class GoFast : MonoBehaviour
{
    public Material originalMat;
    MeshRenderer playerMesh;
    GameObject playerCube;
    public Material fastMaterial;
    public Cube cube;
    private bool isFast = true;
    private float initialHSpeed;
    private float initialSpeed;
    private void Start() 
    {
        playerCube = GameObject.Find("Player Cube");
        cube = playerCube.GetComponent<Cube>();
        playerMesh = playerCube.GetComponentInChildren<MeshRenderer>();   
    }
    private void OnTriggerExit(Collider other) 
    {
        if (isFast)
        {
            StopCoroutine(EnableFast());
            StartCoroutine(EnableFast());
        }
    }
    IEnumerator EnableFast()
    {
        
        initialHSpeed = cube.horizontalSpeed;
        initialSpeed = cube.speed;
        SetNewMaterial();
        cube.speed = cube.speed*1.6f;
        cube.horizontalSpeed = cube.horizontalSpeed*1.6f;
        isFast = false;
        yield return new WaitForSeconds(3f);
        SetOriginalMaterial();
        cube.speed = initialSpeed;
        cube.horizontalSpeed = initialHSpeed;
        isFast = true;
        StopCoroutine(EnableFast());
    }
    private void SetNewMaterial()
    {
        playerMesh.sharedMaterial = fastMaterial;
    }
    private void SetOriginalMaterial()
    {
        playerMesh.sharedMaterial = originalMat;
    }
}
