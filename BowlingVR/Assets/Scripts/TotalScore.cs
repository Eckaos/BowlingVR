using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    private Text textComponent;
    private void Awake() {
        turnManager.OnScoring += SetTotalScore;
        turnManager.OnChangingPlayer += SetTotalScore;
        textComponent = GetComponent<Text>();
    }

    private void SetTotalScore(TurnScore scoreToAdd, int totalScore)
    {
        UpdateUI(totalScore);
    }

    private void SetTotalScore(List<TurnScore> playerScores, int totalScore)
    {
        UpdateUI(totalScore);
    }


    private void UpdateUI(int totalScore)
    {
        textComponent.text = totalScore.ToString();
    }
}
