using UnityEngine;
public class DespawnLevel : MonoBehaviour
{
    GameController gameController;
    Cube cube;
    private void Start() 
    {
        cube = GameObject.Find("Player Cube").GetComponent<Cube>();
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();  
    }
    private void OnTriggerExit(Collider other) 
    {
        cube.speed += 0.35f;
        gameController.damageAmount += 0.01f;
        Destroy(transform.parent.gameObject);
    }
}
