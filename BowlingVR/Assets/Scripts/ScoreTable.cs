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

    public void AddScoreToDisplay(int score)
    {
        Text textComponentToChange = scoreTexts.FirstOrDefault(textComponent => textComponent.text == "");
        if(textComponentToChange == null) return;
        if(score == 10)
        {
            textComponentToChange.text = " ";
            textComponentToChange = scoreTexts.FirstOrDefault(textComponent => textComponent.text == "");
        }
        textComponentToChange.text = GetTextToDisplayFromScore(score);
        previousScores.Push(score);
    }

    public void ChangePlayer(Stack<int> playerScores, int totalScore)
    {
        previousScores.Clear();
        List<int> scores = new List<int>(playerScores);

        foreach (Text t in scoreTexts)
            t.text = "";

        for (int i = scores.Count - 1; i >= 0 ; i--)
        {
            AddScoreToDisplay(scores[i]);
        }
    }

    private string GetTextToDisplayFromScore(int score)
    {
        if(Spare(score, previousScores))
            return "/";
        else if(Strike(score, previousScores))
            return "X";
        else if(score == 0)
            return "-";
        
        return score.ToString();
    }
    private bool Strike(int score, Stack<int> scoreList) => score == 10 && scoreList.Count() > 0 && scoreList.Count() % 2 == 0;
    private bool Spare(int score, Stack<int> scoreList) => scoreList.Count > 0 && scoreList.Count % 2 == 1 && scoreList.Peek() < 10 && score+scoreList.Peek() == 10;
}
