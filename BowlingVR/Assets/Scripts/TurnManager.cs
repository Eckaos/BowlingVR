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
    public GameObject kegelsPrefab;

    public ScoreTable scoreTable;

    public bool isGutter;

    public Gutter gutter;
    private void Start() {
        players = GameObject.FindGameObjectsWithTag("Player").Select(gameObject => gameObject.GetComponent<Player>()).ToList();
        player = players[playerIndex];
    }
    public void Score(int kegels)
    {
        this.fallenKegels += kegels;
        throws++;
        Scoring(kegels);
        score.text = player.GetTotalScore().ToString();
        scoreTable.SetScores(player.score);
        StartCoroutine(DisplaySpecialResult());
        if(throws >= 2 || fallenKegels == 10) NextTurn();
    }

    void Scoring(int kegels){
        player.score.Add(player.scoreCalculator.CalculateTurn(kegels));
        isGutter = kegels == 0 ? true : false;
        if(IsStrike())
            player.scoreCalculator.doubleScoreCount += 2;
        if(IsSpare())
            player.scoreCalculator.doubleScoreCount++;
    }

    void NextTurn(){
        throws = 0;
        fallenKegels = 0;
        playerIndex++;
        if(playerIndex >= players.Count) playerIndex = 0;
        player = players[playerIndex];
        StartCoroutine(RegenerateKegels());
    }
    bool IsStrike() => fallenKegels == 10 && throws == 1;
    bool IsSpare() => fallenKegels == 10 && throws == 2;
    bool IsGutter() => isGutter;

    public IEnumerator DisplaySpecialResult()
    {
        if (IsStrike())
        {
            specialResult.text = "Strike";
        }
        else if (IsSpare()) {
            specialResult.text = "Spare";
    }
        else if (IsGutter()) {
            specialResult.text = "Gutter";
        }
        yield return new WaitForSeconds(2);
        specialResult.text = "";
    }

    public IEnumerator RegenerateKegels() {
        yield return new WaitForSeconds(2);
        Vector3 kegelsPosition = gutter.kegelManager.transform.position;
        Destroy(gutter.kegelManager.gameObject);
        gutter.kegelManager = Instantiate(kegelsPrefab, kegelsPosition, Quaternion.identity).GetComponent<KegelManager>();
    }
}
