using UnityEngine;
public class PassSphere : MonoBehaviour
{
    public bool decSize;
    float rate;
    private MenuButtons menuButtons;
    private GameController gameController;
    private void Start() 
    {
        menuButtons = GameObject.FindGameObjectWithTag("InGameCanvas").GetComponent<MenuButtons>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rate = 0.05f;
        if (menuButtons.gameStarted)
        {
            decSize = true;
        }
    }
    private void Update() 
    {
        if (decSize)
        {
            transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Vector3.zero, rate * Time.unscaledDeltaTime);
            if (transform.localScale.x < 0.5)
            {
                Destroy(gameObject,0.8f);
            }
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        gameController.IncreaseHighScore(transform.localScale.x);
        gameController.ResetHealth();
        if (gameController.vibrate)
        {
            Handheld.Vibrate();
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        Destroy(gameObject);    
    }
}
