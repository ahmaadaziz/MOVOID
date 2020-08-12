using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
public class MenuButtons : MonoBehaviour
{
    public GameObject panelBackground;
    public GameObject instructionsPanel;
    public GameObject closeButton;
    public bool gameStarted;
    public VolumeProfile main;
    Cube cube;
    GameController gameController;
    PassSphere passSphere;
    public GameObject joystick;
    GameObject mainMenu;
    GameObject pauseMenu;
    private bool pointerDown;
    private bool pointerUp;
    private float slowFactor;
    private Volume volume;
    private AudioSource musicSource;
    private void Start() 
    {
        slowFactor = 0.2f;
        gameStarted = false;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        passSphere = GameObject.Find("Pass Sphere").GetComponent<PassSphere>();
        pauseMenu = GameObject.FindGameObjectWithTag("pause");
        mainMenu = GameObject.FindGameObjectWithTag("mainmenu");  
        cube = GameObject.Find("Player Cube").GetComponent<Cube>();
        volume = GameObject.FindGameObjectWithTag("volume").GetComponent<Volume>();
        musicSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        joystick.SetActive(true);
        mainMenu.SetActive(false);
        if (PlayerPrefs.GetString("instruction","no") == "yes")
        {
            volume.profile = main;
            gameStarted = true;
            gameController.decHealth = true;
            cube.changeProfile = true;
            passSphere.decSize = true;
        }
        else
        {
            panelBackground.SetActive(true);
            instructionsPanel.SetActive(true);
            closeButton.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        joystick.SetActive(false);
        gameStarted = false;
        cube.changeProfile = false;
        gameController.decHealth = false;
        passSphere.decSize = false;
    }
    public void ExitToMainMenu()
    {
        PlayerPrefs.SetString("Fireworksplayed","no");
        SceneManager.LoadScene(0);
    }
    public void ResumeGame()
    {
        joystick.SetActive(true);
        gameStarted = true;
        cube.changeProfile = true;
        gameController.decHealth = true;
        passSphere.decSize = true;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

    }
    public void SloMoPointerDown()
    {
        Time.timeScale = slowFactor;
        gameController.damageAmount = 8f;
        if (cube.changeProfile)
        {
            musicSource.pitch = 0.88f;
        }
    }
    public void SloMoPointerUp()
    {
        Time.timeScale = 1f;
        gameController.damageAmount = 5.5f;
        if(cube.changeProfile)
        {
            musicSource.pitch = 1f;
        }
    }
    public void Intructions()
    {
        gameStarted = true;
        gameController.decHealth = true;
        cube.changeProfile = true;
        passSphere.decSize = true;
        PlayerPrefs.SetString("instruction","yes");
    }
}
