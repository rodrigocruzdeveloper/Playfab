using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    PlayfabManager manager;

    void Start()
    {
        manager = GameObject.Find("PlayfabManager").GetComponent<PlayfabManager>();

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
        UpdateScore();

        // Enviado a pontução para o playfab
        if(score % 10 == 0)
        {
            manager.SendScore(score);
        }

    }


}
