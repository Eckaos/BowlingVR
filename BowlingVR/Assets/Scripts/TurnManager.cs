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

    public delegate void ScoreUpdate(int score);
    public event ScoreUpdate OnScoring;

    public delegate void ChangePlayer(Stack<int> scores, int totalScore);
    public event ChangePlayer OnChangingPlayer;

    public delegate void EndGame();
    public event EndGame OnEndGame;
    
    private void Start() 
    {
        players = new Queue<Player>(GameObject.FindGameObjectsWithTag("Player").Select(gameObject => gameObject.GetComponent<Player>()));
        player = players.Dequeue();
    }
    public void Scoring(int fallenKegels)
    {  
        throws++;
        player.CalculateTurn(fallenKegels);
        if(OnScoring != null) OnScoring.Invoke(fallenKegels);
        if(player.turn > 9 && (fallenKegels == 10 || (player.scores.Peek() + fallenKegels == 10 && throws > 0)))
            maxThrowPossibleInOneTurn = 3;
        if(throws >= maxThrowPossibleInOneTurn || fallenKegels == 10) NextTurn();
    }

    void NextTurn()
    {
        throws = 0;
        maxThrowPossibleInOneTurn = 2;
        player.turn++;
        players.Enqueue(player);
        player = players.Dequeue();
        if(player.turn > 10 && OnEndGame != null)
            OnEndGame.Invoke();
        
        StartCoroutine(RegenerateKegels());
        if(OnChangingPlayer != null)
            OnChangingPlayer.Invoke(player.scores, player.GetTotalScore());
    }

    public IEnumerator RegenerateKegels() 
    {
        yield return new WaitForSeconds(2);
        kegelSpawner.RespawnKegels();
    }
}
