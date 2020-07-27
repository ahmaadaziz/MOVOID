using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
public class DecreaseHealth : MonoBehaviour
{
    private Cube cube;
    private Volume ppVolume;
    public VolumeProfile damageProfile;
    public GameController gameController;
    private float damageAmount = 8f;
    private void Start() 
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        ppVolume = GameObject.FindGameObjectWithTag("volume").GetComponent<Volume>();  
        cube = GameObject.Find("Player Cube").GetComponent<Cube>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        gameController.TakeDamage(damageAmount);
        Debug.Log("Damage");
        if (gameController.vibrate)
        {
            Handheld.Vibrate();
            Debug.Log("Vibrate");
        }
        StartCoroutine(DamageEffect());
        Debug.Log("Effect");
    }
    IEnumerator DamageEffect()
    {
        cube.changeProfile = false;
        ppVolume.profile = damageProfile;
        yield return new WaitForSecondsRealtime(0.09f);
        cube.changeProfile = true;
        Destroy(gameObject);    
        //StopCoroutine(DamageEffect());
    }
}
