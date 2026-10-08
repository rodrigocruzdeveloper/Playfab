using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void UpdateScore()
    {
        Debug.Log("SOCORE: " + score);
    }

    public void AddScore(int s)
    {
        score += s;
    }
}
