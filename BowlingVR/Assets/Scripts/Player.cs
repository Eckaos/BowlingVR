using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Stack<int> scores;
    public int totalScore = 0;
    public BowlingScoreCalculator scoreCalculator;
    private List<TurnScore> scoreList;
    private TurnScore currentTurnScore;
    void Start()
    {
        scoreCalculator = new BowlingScoreCalculator();
        scoreList = new List<TurnScore>();
    }
    public int GetTotalScore(){
        return totalScore;
    }

    public void CalculateTurn(int score)
    {
        currentTurnScore.AddScore(score);
        totalScore += scoreCalculator.CalculateTurn(score);
        if(currentTurnScore.Spare()) 
            scoreCalculator.doubleScoreCount++;
        else if(currentTurnScore.Strike())
            scoreCalculator.doubleScoreCount += 2;
    }

    public void AddTurnScore()
    {
        currentTurnScore = new TurnScore();
        scoreList.Add(currentTurnScore);
    }

    public TurnScore GetTurnScore() => currentTurnScore;
    public List<TurnScore> GetTurnScores() => scoreList;
}
