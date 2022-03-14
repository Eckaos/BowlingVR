using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    private List<Player> players;
    private Player player;
    private int fallenKegels = 0;
    private int throws = 0;
    private int playerIndex = 0;
    public Text specialResult;
    public Text score;
    private void Start() {
        players = GameObject.FindGameObjectsWithTag("Player").Select(gameObject => gameObject.GetComponent<Player>()).ToList();
        player = players[playerIndex];
    }
    public void Score(int kegels)
    {
        if(kegels == fallenKegels) return;
        this.fallenKegels += kegels;
        Scoring(kegels);
        throws++;
        if(throws >= 2) NextTurn();
    }

    private void Update() {
        StartCoroutine(DisplaySpecialResult());
    }

    void Scoring(int kegels){
        player.score.Add(player.scoreCalculator.CalculateTurn(kegels));
        if(IsStrike())
            player.scoreCalculator.doubleScoreCount += 2;
        if(IsSpare())
            player.scoreCalculator.doubleScoreCount++;
        score.text = player.GetTotalScore().ToString();
    }

    void NextTurn(){
        throws = 0;
        fallenKegels = 0;
        playerIndex++;
        if(playerIndex >= players.Count) playerIndex = 0;
        player = players[playerIndex];
    }
    bool IsStrike() => fallenKegels == 10 && throws == 1;
    bool IsSpare() => fallenKegels == 10 && throws == 2;
    bool IsGutter() => fallenKegels == 0 && throws > 0;

    public IEnumerator DisplaySpecialResult()
    {
        if(IsStrike())
            specialResult.text = "Strike";
        else if(IsSpare())
            specialResult.text = "Spare";
        else if(IsGutter())
            specialResult.text = "Gutter";
        else
            specialResult.text = "";
        
        yield return new WaitForSeconds(2);
    }
}
