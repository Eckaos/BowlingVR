using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreTable : MonoBehaviour
{
    [SerializeField]private List<Text> scoreTexts;
    [SerializeField] private TurnManager turnManager;
    private Stack<int> previousScores;


    private void Awake() {
        previousScores = new Stack<int>();
        turnManager.OnScoring += AddScoreToDisplay;
        turnManager.OnChangingPlayer += ChangePlayer;
    }

    public void AddScoreToDisplay(TurnScore score, int totalScore)
    {
        Text textComponentToChange = scoreTexts.FirstOrDefault(textComponent => textComponent.text == "");
        if(textComponentToChange == null) return;
        string specialResult = GetSpecialResultDisplay(score);
        if(specialResult == "")
        {

            if(score.T1Gutter())
                textComponentToChange.text = "-";
            else
                textComponentToChange.text = score.throw1.ToString();
            
            textComponentToChange = scoreTexts.FirstOrDefault(textComponent => textComponent.text == "");

            if(score.T2Gutter())
                textComponentToChange.text = "-";
            else
                textComponentToChange.text = score.throw2.ToString();
        }
        else if(specialResult == "X")
        {
            textComponentToChange.text = " ";
            textComponentToChange = scoreTexts.FirstOrDefault(textComponent => textComponent.text == "");
            textComponentToChange.text = specialResult;
        }
        else if(specialResult == "/")
        {
            textComponentToChange.text = score.throw1.ToString();
            textComponentToChange = scoreTexts.FirstOrDefault(textComponent => textComponent.text == "");
            textComponentToChange.text = specialResult;
        }
    }

    public void ChangePlayer(List<TurnScore> playerScores, int totalScore)
    {
        foreach (Text t in scoreTexts)
            t.text = "";

        foreach (TurnScore score in playerScores)
        {
            AddScoreToDisplay(score, totalScore);
        }
    }

    private string GetSpecialResultDisplay(TurnScore score)
    {
        if(score.Spare())
            return "/";
        else if(score.Strike())
            return "X";
        else return "";
    }
}
