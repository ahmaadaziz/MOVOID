using UnityEngine;
public class ResetScore : MonoBehaviour
{
    GameController gameController;
    NumberAnimation numberAnimation;
    private void Start() 
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        numberAnimation = GameObject.Find("Game Controller").GetComponent<NumberAnimation>();    
    }
    private void OnTriggerEnter(Collider other) 
    {
        gameController.HighScore = 0f;
        numberAnimation.desiredNumber = 0f;
        Destroy(gameObject);
    }
}
