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

    private void DisplaySpecialResult(TurnScore score, int totalScore)
    {
        StartCoroutine(SetSpecialResult(score));
    }

    private IEnumerator SetSpecialResult(TurnScore score)
    {
        if((score.T1Gutter() && score.throw2 == -1) || score.T2Gutter()) 
            textComponent.text = "Gutter";
        else if(score.Strike()) 
            textComponent.text = "Strike";
        else if(score.Spare()) 
            textComponent.text = "Spare";
            
        yield return new WaitForSeconds(3);
        textComponent.text = "";
    }

    private void EndGame()
    {
        textComponent.text = "End of Game";
    }

}
