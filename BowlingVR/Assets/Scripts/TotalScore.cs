using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    private Text textComponent;
    private int score = 0;
    private void Awake() {
        turnManager.OnScoring += SetTotalScore;
        turnManager.OnChangingPlayer += SetTotalScore;
        textComponent = GetComponent<Text>();
    }

    private void SetTotalScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateUI(score);
    }

    private void SetTotalScore(Stack<int> playerScores, int totalScore)
    {
        score = totalScore;
        UpdateUI(totalScore);
    }


    private void UpdateUI(int totalScore)
    {
        textComponent.text = totalScore.ToString();
    }
}
