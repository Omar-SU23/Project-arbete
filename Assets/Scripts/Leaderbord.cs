using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leaderbord : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoretxt;

    void Start()
    {
        scoretxt.text = GameManager.instance.currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
