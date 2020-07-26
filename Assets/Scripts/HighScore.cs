using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
    NumberAnimation numberAnimation;
    GameController gameController;
    private TextMeshProUGUI highScore;
    private void Start() 
    {
        numberAnimation = GameObject.FindGameObjectWithTag("GameController").GetComponent<NumberAnimation>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<TextMeshProUGUI>();
        highScore.text = PlayerPrefs.GetFloat("HighScore",0f).ToString("#.##");
    }
    private void Update() 
    {
        if (numberAnimation.desiredNumber > PlayerPrefs.GetFloat("HighScore",0))
        {
            PlayerPrefs.SetFloat("HighScore",gameController.HighScore);
            highScore.text = numberAnimation.desiredNumber.ToString("#.##");
            if (PlayerPrefs.GetString("Fireworksplayed","no") == "no")
            {
                highScore.fontStyle = TMPro.FontStyles.Underline;
                highScore.color = new Color32(205,102,77,255);
                PlayerPrefs.SetString("Fireworksplayed","yes");
            }
        }    
    }
}
