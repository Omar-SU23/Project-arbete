using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; // Singleton Class

    public int currentScore = 0;
    public GameObject player;

    void Awake()
    {
        // Singleton class, only one instance. Don't remove this.
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        GameData.LoadData();

    }

    private void OnApplicationQuit()
    {
        GameData.SaveData();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        if (currentScore > GameData.highscore)
        {
            GameData.highscore = currentScore;
        }
    }

    // Add methods here

}
