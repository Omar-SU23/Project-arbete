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
        scoretxt.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Addscore()
    {
        score += Random.Range(100, 500);
        scoretxt.text = score.ToString();
    }
}
