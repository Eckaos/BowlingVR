using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Stack<int> scores;
    int totalScore = 0;
    public BowlingScoreCalculator scoreCalculator;
    public int turn;
    void Start()
    {
        scores = new Stack<int>();
        scoreCalculator = new BowlingScoreCalculator();
        turn = 0;
    }
    public int GetTotalScore(){
        return totalScore;
    }

    public void CalculateTurn(int score)
    {
        totalScore += scoreCalculator.CalculateTurn(score);
        if(scores.Count > 0 && scores.Count % 2 == 1 && scores.Peek() < 10 && score+scores.Peek() == 10) 
            scoreCalculator.doubleScoreCount++;
        else if(score == 10 && scores.Count > 0 && scores.Count % 2 == 0)
            scoreCalculator.doubleScoreCount += 2;
        scores.Push(score);
    }

    private bool Strike(int score) => score == 10 && scores.Count > 0 && scores.Count % 2 == 0;
    private bool Spare(int score) => scores.Count > 0 && scores.Count % 2 == 1 && scores.Peek() < 10 && score+scores.Peek() == 10;
}
