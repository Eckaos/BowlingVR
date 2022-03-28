using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingScoreCalculator
{
    public int doubleScoreCount = 0;

    public int CalculateTurn(int numberOfFallenPins){
        Debug.Log(doubleScoreCount);
        if(doubleScoreCount > 0){
            doubleScoreCount--;
            return numberOfFallenPins*2;
        }
        return numberOfFallenPins;
    }
}
