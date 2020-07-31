using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
public class DecreaseHealth : MonoBehaviour
{
    private AudioSource damageSource;
    private GameObject playerCube;
    private Cube cube;
    private Volume ppVolume;
    public VolumeProfile damageProfile;
    public GameController gameController;
    private float damageAmount = 8f;
    private void Start() 
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        ppVolume = GameObject.FindGameObjectWithTag("volume").GetComponent<Volume>();
        playerCube =  GameObject.Find("Player Cube");
        cube = playerCube.GetComponent<Cube>();
        damageSource = playerCube.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        gameController.TakeDamage(damageAmount);
        if (gameController.vibrate)
        {
            Handheld.Vibrate();
        }
        StopCoroutine(DamageEffect());
        StartCoroutine(DamageEffect());
    }
    IEnumerator DamageEffect()
    {
        damageSource.Play();
        cube.changeProfile = false;
        ppVolume.profile = damageProfile;
        yield return new WaitForSecondsRealtime(0.09f);
        cube.changeProfile = true;
        Destroy(gameObject);
    }
}
