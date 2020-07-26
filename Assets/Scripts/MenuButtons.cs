using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    public bool gameStarted = false;
    Cube cube;
    GameController gameController;
    PassSphere passSphere;
    public GameObject joystick;
    GameObject mainMenu;
    GameObject pauseMenu;
    private void Start() 
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        passSphere = GameObject.Find("Pass Sphere").GetComponent<PassSphere>();
        pauseMenu = GameObject.FindGameObjectWithTag("pause");
        mainMenu = GameObject.FindGameObjectWithTag("mainmenu");  
        cube = GameObject.Find("Player Cube").GetComponent<Cube>();
    }
    public void PlayGame()
    {
        joystick.SetActive(true);
        gameStarted = true;
        gameController.decHealth = true;
        cube.changeProfile = true;
        passSphere.decSize = true;
        mainMenu.SetActive(false);
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
}
