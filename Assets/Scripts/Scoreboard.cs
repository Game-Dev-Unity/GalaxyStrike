using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text scoreboardText;
    public void IncrementScore(int amount)
    {
        score += amount;
        scoreboardText.text = score.ToString();
    }
}
