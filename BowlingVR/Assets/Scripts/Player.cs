using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Stack<int> scores;
    public BowlingScoreCalculator scoreCalculator;
    public int turn;
    void Start()
    {
        scores = new Stack<int>();
        scoreCalculator = new BowlingScoreCalculator();
        turn = 0;
    }
    public int GetTotalScore(){
        return scores.Sum();
    }

    public void CalculateTurn(int score)
    {
        scores.Push(scoreCalculator.CalculateTurn(score));
        if(score == 10) scoreCalculator.doubleScoreCount += 2;
        if(scores.Count > 0 && scores.Peek() < 10 && score+scores.Peek() == 10) scoreCalculator.doubleScoreCount++;
    }
}
