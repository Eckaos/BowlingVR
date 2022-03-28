using System;

public class TurnScore {
    
    public int throw1;
    public int throw2;
    private int additionalThrow;
    public bool haveAdditionalThrow = false;
    public TurnScore()
    {
        throw1 = -1;
        throw2 = -1;
    }

    public void AddScore(int score)
    {
        if(throw1 == -1)
            throw1 = score;
        else
            throw2 = score;

        if(throw1 == 10)
            throw2 = 0;
    }

    public void AddAThrow()
    {
        haveAdditionalThrow = true;
    }

    public bool Spare() => throw1+throw2 == 10 && throw2 > -1;
    public bool Strike() => throw1 == 10;
    public bool IsTurnFinished() => (throw1 > -1 && throw2 > -1) || throw1 == 10;
    public bool T1Gutter() => throw1 == 0;
    public bool T2Gutter() => throw2 == 0;
}