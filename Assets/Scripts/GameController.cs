using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using EZCameraShake;
using UnityEngine.Advertisements;
public class GameController : MonoBehaviour
{
    private int deaths;
    private string GooglePlayID = "3740809";
    bool testMode = true;
    private AudioSource explosionSource;
    private GameObject explotionObj;
    public GameObject level0;
    public Button pauseButton;
    private CanvasGroup hbarCanvas;
    private bool restartStarted;
    public bool vibrate;
    private ParticleSystem explosion;
    public bool decHealth = false;
    private NumberAnimation numberAnimation;
    public float damageAmount;
    private GameObject playerCube;
    public float HighScore;
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBar healthBar;
    private Vector3 levelSpawnPos;
    private void Awake() 
    {
        levelSpawnPos = new Vector3(8.533161f,5.552793f,32.25724f);
        Instantiate(level0,levelSpawnPos,Quaternion.identity);
    }
    private void Start() 
    {
        Advertisement.Initialize(GooglePlayID,testMode);
        hbarCanvas = GameObject.FindGameObjectWithTag("hbarcanvas").GetComponent<CanvasGroup>();
        playerCube = GameObject.FindGameObjectWithTag("playercube");
        explotionObj = GameObject.FindGameObjectWithTag("explosion");
        explosion = explotionObj.GetComponent<ParticleSystem>();
        explosionSource = explotionObj.GetComponent<AudioSource>(); 
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        numberAnimation = gameObject.GetComponent<NumberAnimation>();
        damageAmount = 5.5f;
        decHealth = false;
        restartStarted = true;
        vibrate = true;
        if (PlayerPrefs.GetInt("ads",0) == 3 || PlayerPrefs.GetInt("ads",0) % 3 == 0 )
        {
            Advertisement.Show();
        }
    }
    private void Update() 
    {
        if (decHealth)
        {
            TakeDamage(damageAmount * Time.unscaledDeltaTime); 
        }
        if (currentHealth < 0 && restartStarted)
        {
            deaths = PlayerPrefs.GetInt("ads",0) + 1;
            PlayerPrefs.SetInt("ads",deaths);
            restartStarted = false;
            StopCoroutine(Restart());
            StartCoroutine(Restart());
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseButton.onClick.Invoke();
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
        explosionSource.Play();
        Handheld.Vibrate();
        CameraShaker.Instance.ShakeOnce(4f,4f,0.1f,1f);
        playerCube.SetActive(false);
        LeanTween.alphaCanvas(hbarCanvas,0.0f,0.01f);
        yield return new WaitForSecondsRealtime(2f);
        //Advertisement.Show();
        SceneManager.LoadScene(0);
        StopCoroutine(Restart());
    }
    public void SetVibration(bool shouldVibrate)
    {
        vibrate = shouldVibrate;
    }
}
