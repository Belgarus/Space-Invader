using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private HighScoreData highscore;

    private void Update()
    {
        text.text = highscore.currentScore.ToString();
    }

    private void OnDisable()
    {
        highscore.currentScore = 0;
    }
}
