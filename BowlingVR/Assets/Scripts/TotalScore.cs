using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    private Text textComponent;
    private int score;
    private void Awake() {
        turnManager.OnScoring += SetTotalScore;
        textComponent = GetComponent<Text>();
    }

    private void SetTotalScore(int scoreToAdd)
    {
        score += scoreToAdd;
        textComponent.text = score.ToString();
    }
}
