using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{
    [SerializeField]private List<Text> scoreTexts;

    public void SetScores(List<int> scores)
    {
        int index = 0;
        foreach (var score in scores)
        {
            if(score == 10)
                scoreTexts[++index].text = "X";
            else if(index%2 == 0 && index >0 && scoreTexts[index-1].text != "-" && score+int.Parse(scoreTexts[index-1].text) == 10)
                scoreTexts[index].text = "/";
            else if(score == 0)
                scoreTexts[index].text = "-";
            else
                scoreTexts[index].text = score.ToString();
            
            index++;
        }
    }
}
