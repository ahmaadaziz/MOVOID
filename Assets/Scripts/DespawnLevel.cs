using UnityEngine;
public class DespawnLevel : MonoBehaviour
{
    GameController gameController;
    Cube cube;
    private void Start() 
    {
        cube = GameObject.Find("Player Cube").GetComponent<Cube>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>(); 
    }
    private void OnTriggerEnter(Collider other) 
    {
        cube.isInverted = false; 
    }
    private void OnTriggerExit(Collider other) 
    {
        cube.speed += 17.5f;
        cube.horizontalSpeed += 2.5f;
        gameController.damageAmount += 0.01f;
        Destroy(transform.parent.gameObject);
    }
}
