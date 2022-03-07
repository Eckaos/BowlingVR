using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private List<Player> players;
    public Player player;
    private int fallenKegels = 0;
    private int throws = 1;

    private int playerIndex = 0;

    public void Turn(int kegels){
        this.fallenKegels += kegels; 
        Scoring(kegels);
        EndTurn();
    }

    void Scoring(int kegels){
        player.score.Add(player.scoreCalculator.CalculateTurn(kegels));
    }

    void EndTurn(){
        if(throws < 2 && fallenKegels < 10) throws++;
        else InitNextTurn();
    }

    void InitNextTurn(){
        if(isStrike())
            player.scoreCalculator.doubleScoreCount += 2;
        if(isSpare())
            player.scoreCalculator.doubleScoreCount++;
        throws = 1;
        fallenKegels = 0;
    }

    bool isStrike(){
        return fallenKegels == 10 && throws == 1;
    }
    bool isSpare(){
        return fallenKegels == 10 && throws == 2;
    }
}
