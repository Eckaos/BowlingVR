using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialResult : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    private int previousScore;
    private Text textComponent;
    private string specialResult;

    private void Awake() {
        previousScore = 0;
        turnManager.OnScoring += DisplaySpecialResult;
        turnManager.OnEndGame += EndGame;
        textComponent = GetComponent<Text>();
    }

    private void DisplaySpecialResult(int score)
    {
        StartCoroutine(SetSpecialResult(score));
        previousScore = score;
    }

    private IEnumerator SetSpecialResult(int score)
    {
        if(score == 0) 
            textComponent.text = "Gutter";
        else if(score == 10) 
            textComponent.text = "Strike";
        else if(score+previousScore == 10 && previousScore < 10) 
            textComponent.text = "Spare";
            
        yield return new WaitForSeconds(3);
        textComponent.text = "";
    }

    private void EndGame()
    {
        textComponent.text = "End of Game";
    }

}
