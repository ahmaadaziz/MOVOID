using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using EZCameraShake;
public class GameController : MonoBehaviour
{
    private CanvasGroup hbarCanvas;
    private bool restartStarted;
    private ParticleSystem explosion;
    public bool decHealth = false;
     private NumberAnimation numberAnimation;
     public float damageAmount;
     private GameObject playerCube;
     private Cube cube;
     public float HighScore;
     public float maxHealth = 100f;
     public float currentHealth;
     public HealthBar healthBar;
     private void Start() 
     {
         hbarCanvas = GameObject.FindGameObjectWithTag("hbarcanvas").GetComponent<CanvasGroup>();
         playerCube = GameObject.FindGameObjectWithTag("playercube");
         cube = GameObject.Find("Player Cube").GetComponent<Cube>();
         explosion = GameObject.FindGameObjectWithTag("explosion").GetComponent<ParticleSystem>();
         currentHealth = maxHealth;
         healthBar.SetMaxHealth(maxHealth);
         numberAnimation = gameObject.GetComponent<NumberAnimation>();
         damageAmount = 5f * Time.unscaledDeltaTime;
         decHealth = false;
         restartStarted = true;
     }
     private void FixedUpdate() 
     {
        if (!cube.isMoving && decHealth)
        {
            TakeDamage(damageAmount); 
        }
        if (currentHealth < 0 && restartStarted)
        {
            restartStarted = false;
            StartCoroutine(Restart());
        }
     }
     public void IncreaseHighScore(float score)
    {
        HighScore = HighScore + score;
        numberAnimation.AddToScore(score);
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
    IEnumerator Restart()
    {
        explosion.Play(true);
        CameraShaker.Instance.ShakeOnce(4f,4f,0.1f,1f);
        playerCube.SetActive(false);
        LeanTween.alphaCanvas(hbarCanvas,0.0f,0.01f);
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(0);
        StopCoroutine("Restart");
    }
}
