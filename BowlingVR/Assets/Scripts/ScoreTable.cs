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
        Queue<int> scores = new Queue<int>(playerScores);
        
        foreach (Text t in scoreTexts)
            t.text = "";

        foreach (int score in scores)
            AddScoreToDisplay(score);
    }

    private string GetTextToDisplayFromScore(int score)
    {
        if(score == 10)
            return "X";
        if(score == 0)
            return "-";
        if(previousScores.Count > 0 && previousScores.Peek() + score == 10)
            return "/";
        return score.ToString();
    }
}
