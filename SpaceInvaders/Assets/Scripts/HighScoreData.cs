using UnityEngine;

[CreateAssetMenu(fileName = "highscore", menuName = "ScriptableObjects/HighScore")]
public class HighScoreData : ScriptableObject
{
    public int currentScore;
    public int[] maxScore = new int[5];

    public void SortMaxScore()
    {
        for (int i = 0; i < maxScore.Length; i++)
        {
            for (int j = 0; j < maxScore.Length -1; j++) 
            {
                if (maxScore[j] > maxScore[j + 1])
                {
                    int temp = maxScore[i];
                    maxScore[i] = maxScore[j];
                    maxScore[j] = temp;
                }
            }
        }
    }

    public void NewScore()
    {
        for (int i = 0; i < maxScore.Length; i++)
        {
            for (int j = 0; j < maxScore.Length - 1; j++)
            {
                if (currentScore > maxScore[j])
                {
                    int temp = maxScore[j];
                    maxScore[j] = currentScore;
                    currentScore = temp;
                }
            }
        }
    }
}