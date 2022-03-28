using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;

    int score;

    void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public ScoreKeeper GetInstance()
    {
        return instance;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
