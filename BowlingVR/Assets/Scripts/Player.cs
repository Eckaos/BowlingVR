using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<int> score;
    public BowlingScoreCalculator scoreCalculator;
    void Start()
    {
        score = new List<int>();
        scoreCalculator = new BowlingScoreCalculator();
    }
    public int GetTotalScore(){
        return score.Sum();
    }
}
