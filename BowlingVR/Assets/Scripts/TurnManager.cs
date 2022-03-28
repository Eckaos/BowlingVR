using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private KegelSpawner kegelSpawner;

    private Queue<Player> players;
    private Player player;
    private int throws = 0;
    private int maxThrowPossibleInOneTurn = 2;

    public delegate void ScoreUpdate(TurnScore score, int totalScore);
    public event ScoreUpdate OnScoring;

    public delegate void ChangePlayer(List<TurnScore> scores, int totalScore);
    public event ChangePlayer OnChangingPlayer;
    public delegate void EndGame();
    public event EndGame OnEndGame;
    
    private void Start() 
    {
        players = new Queue<Player>(GameObject.FindGameObjectsWithTag("Player").Select(gameObject => gameObject.GetComponent<Player>()));
        player = players.Dequeue();
        player.AddTurnScore();
    }
    public void Scoring(int fallenKegels)
    {  
        var currentTurnScore = player.GetTurnScore();
        player.CalculateTurn(fallenKegels);
        if(OnScoring != null) OnScoring.Invoke(currentTurnScore, player.GetTotalScore());
        if(player.GetTurnScores().Count > 9 && (currentTurnScore.Strike() || currentTurnScore.Spare()))
            currentTurnScore.AddAThrow();
        if((currentTurnScore.IsTurnFinished() && !currentTurnScore.haveAdditionalThrow) || currentTurnScore.Strike()) NextTurn();
    }

    void NextTurn()
    {
        players.Enqueue(player);
        player = players.Dequeue();
        player.AddTurnScore();
        if(player.GetTurnScores().Count > 10 && OnEndGame != null)
            OnEndGame.Invoke();
        
        StartCoroutine(RegenerateKegels());
        if(OnChangingPlayer != null)
            OnChangingPlayer.Invoke(player.GetTurnScores(), player.GetTotalScore());
    }

    public IEnumerator RegenerateKegels() 
    {
        yield return new WaitForSeconds(2);
        kegelSpawner.RespawnKegels();
    }
}
