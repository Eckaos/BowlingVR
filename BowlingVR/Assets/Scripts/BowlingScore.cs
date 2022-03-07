using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingScore : MonoBehaviour
{

    List<int> turnScore;


    void AddScore(int score){
        turnScore.Add(score);
    }
    // Start is called before the first frame update
    void Start()
    {
        turnScore = new List<int>();
    }
}
