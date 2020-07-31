using UnityEngine;
using System.Collections;

public class GoSlow : MonoBehaviour
{
    public Material originalMat;
    MeshRenderer playerMesh;
    GameObject playerCube;
    public Cube cube;
    public Material slowMaterial;
    private bool isSlow = true;
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
        if (isSlow)
        {
            StopCoroutine(EnableSlow());
            StartCoroutine(EnableSlow());
        }
    }
    IEnumerator EnableSlow()
    {
        initialHSpeed = cube.horizontalSpeed;
        initialSpeed = cube.speed;
        SetNewMaterial();
        cube.speed = cube.speed/2.3f;
        cube.horizontalSpeed = cube.horizontalSpeed/2.3f;
        isSlow = false;
        yield return new WaitForSeconds(3f);
        SetOriginalMaterial();
        cube.speed = initialSpeed;
        cube.horizontalSpeed = initialHSpeed;
        isSlow = true;
        StopCoroutine(EnableSlow());
    }
    private void SetNewMaterial()
    {
        playerMesh.sharedMaterial = slowMaterial;
    }
    private void SetOriginalMaterial()
    {
        playerMesh.sharedMaterial = originalMat;
    }
}
