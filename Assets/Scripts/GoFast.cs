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
        Debug.Log(playerCube.name);
        cube = playerCube.GetComponent<Cube>();
        playerMesh = playerCube.GetComponentInChildren<MeshRenderer>();   
    }
    private void OnTriggerExit(Collider other) 
    {
        StartCoroutine("EnableFast");
    }
    IEnumerator EnableFast()
    {
        if (isFast)
        {
            Debug.Log("Done");
            initialHSpeed = cube.horizontalSpeed;
            initialSpeed = cube.speed;
            SetNewMaterial();
            cube.speed = cube.speed*1.4f;
            cube.horizontalSpeed = cube.horizontalSpeed*1.4f;
            isFast = false;
        }
        yield return new WaitForSeconds(3f);
        SetOriginalMaterial();
        cube.speed = initialSpeed;
        cube.horizontalSpeed = initialHSpeed;
        isFast = true;
        Debug.Log("Reverted");
        StopCoroutine("EnableFast");
    }
    private void SetNewMaterial()
    {
        playerMesh.sharedMaterial = fastMaterial;
        Debug.Log("Material Changed");
    }
    private void SetOriginalMaterial()
    {
        playerMesh.sharedMaterial = originalMat;
        Debug.Log("Material Changed Back");
    }
}
