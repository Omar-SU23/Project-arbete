using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    // Values to save, change like this: GameData.highscore = 100;
    public static int highscore = 0;


    // Save data, call GameData.SaveData() when game is in a suitable state
    public static void SaveData()
    {
        PlayerPrefs.SetInt("highscore", highscore);
        PlayerPrefs.Save();
    }


    // Load data, call GameData.LoadData() once in a Start or Awake method
    public static void LoadData()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }

}