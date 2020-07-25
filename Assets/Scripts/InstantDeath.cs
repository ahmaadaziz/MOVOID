using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    public GameController gameController;
    private void Start() 
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();    
    }
    private void OnTriggerEnter(Collider other) 
    {
        gameController.currentHealth = 0;
        Destroy(gameObject);
    }
}
