using UnityEngine;

public class DecreaseHealth : MonoBehaviour
{
    public GameController gameController;
    private float damageAmount = 5f;
    private void Start() 
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();    
    }
    private void OnTriggerEnter(Collider other) 
    {
        gameController.TakeDamage(damageAmount);
        Debug.Log("Damage take");
        Destroy(gameObject);    
    }
}
