using UnityEngine;
using UnityEngine.Rendering;
public class DecreaseHealth : MonoBehaviour
{
    private Volume ppVolume;
    public VolumeProfile damageProfile;
    public GameController gameController;
    private float damageAmount = 5f;
    private void Start() 
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        ppVolume = GameObject.FindGameObjectWithTag("volume").GetComponent<Volume>();   
    }
    private void OnTriggerEnter(Collider other) 
    {
        gameController.TakeDamage(damageAmount);
        if (gameController.vibrate)
        {
            Handheld.Vibrate();
        }
        ppVolume.profile = damageProfile;
        Destroy(gameObject);    
    }
}
