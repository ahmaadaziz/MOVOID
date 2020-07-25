using UnityEngine;
using TMPro;

public class NumberAnimation : MonoBehaviour
{
    private TextMeshProUGUI CurrentScore;
    MenuButtons menuButtons;
    private float animationTime = 1.5f;
    public float desiredNumber, initialNumber, currentNumber;
    public void AddToScore(float value)
    {
        initialNumber = currentNumber;
        desiredNumber += value;
    }
    private void Start() 
    {
        CurrentScore = GameObject.FindGameObjectWithTag("CurrentScore").GetComponent<TextMeshProUGUI>();
        menuButtons = GameObject.FindGameObjectWithTag("InGameCanvas").GetComponent<MenuButtons>();   
    }
    void Update()
    {
        if (menuButtons.gameStarted)
        {
            currentNumber += (desiredNumber-initialNumber)*(Time.deltaTime*animationTime);
            if(currentNumber>=desiredNumber)
            {
                currentNumber = desiredNumber;
            }
            CurrentScore.text = currentNumber.ToString("#.##");
        }

    }
}
