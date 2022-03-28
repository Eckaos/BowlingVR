using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreTable : MonoBehaviour
{
    [SerializeField]private List<Text> scoreTexts;
    [SerializeField] private TurnManager turnManager;

    private int index;




    private void Awake() {
        turnManager.OnScoring += AddScoreToDisplay;
        turnManager.OnChangingPlayer += ChangePlayer;
        index = 0;
    }

    public void AddScoreToDisplay(TurnScore score, int totalScore)
    {
        if(score.Strike())
        {
            AddStrikeToDisplay();
        }
        else if(score.Spare())
        {
            AddScoreToDisplay(score.throw1);
            AddSpareToDisplay();
        }
        else 
        {
            AddScoreToDisplay(score.throw1);
            AddScoreToDisplay(score.throw2);
            AddScoreToDisplay(score.additionalThrow);
        }
        index++;
    }


    public void AddScoreToDisplay(int score)
    {
        Text textComponentToChange = scoreTexts.FirstOrDefault(textComponent => textComponent.text == "");
        if(textComponentToChange == null) return;
        if(score == -1) return;
        textComponentToChange.text = score.ToString();
    }

    public void AddSpareToDisplay()
    {
        Text textComponentToChange = scoreTexts.FirstOrDefault(textComponent => textComponent.text == "");
        if(textComponentToChange == null) return;
        textComponentToChange.text = "/";
    }

    public void AddStrikeToDisplay()
    {
        Text textComponentToChange = scoreTexts.FirstOrDefault(textComponent => textComponent.text == "");
        if(textComponentToChange == null) return;
        textComponentToChange.text = " ";
        textComponentToChange = scoreTexts.FirstOrDefault(textComponent => textComponent.text == "");
        if(textComponentToChange == null) return;
        textComponentToChange.text = "X";
    }

    public void ChangePlayer(List<TurnScore> playerScores, int totalScore)
    {
        foreach (Text t in scoreTexts)
            t.text = "";

        index = 0;
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
