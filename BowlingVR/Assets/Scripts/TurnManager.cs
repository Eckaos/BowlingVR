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
        StartCoroutine(DisplaySpecialResult());
        if(throws >= 2 || fallenKegels == 10) NextTurn();
    }

    private void Update() {
    }

    void Scoring(int kegels){
        Debug.Log(player.scoreCalculator.doubleScoreCount);
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
        RegenerateKegels();
    }
    bool IsStrike() => fallenKegels == 10 && throws == 1;
    bool IsSpare() => fallenKegels == 10 && throws == 2;
    bool IsGutter() => fallenKegels == 0 && throws > 0;

    public IEnumerator DisplaySpecialResult()
    {
        if (IsStrike())
        {
            Debug.Log("Strike");
            specialResult.text = "Strike";
        }
        else if (IsSpare()) {
            Debug.Log("Spare");
            specialResult.text = "Spare";
    }
        else if (IsGutter()) {
            Debug.Log("Gutter");
            specialResult.text = "Gutter";
        }
        yield return new WaitForSeconds(2);
        specialResult.text = "";
    }

    public void RegenerateKegels() {
        Vector3 kegelsPosition = gutter.kegelsManager.transform.position;
        Destroy(gutter.kegelsManager.gameObject);
        gutter.kegelsManager = Instantiate(kegelsPrefab, kegelsPosition, Quaternion.identity).GetComponent<KegelsManager>();
    }
}
