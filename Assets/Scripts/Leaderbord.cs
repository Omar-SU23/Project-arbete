using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leaderbord : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoretxt;
    public List<int> scores = new List<int>() {0,0,0,0,0,0,0,0,0,0};

    void Start()
    {
        scoretxt.text = score.ToString();
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

    public void Savescore(int score)
    {
        
    }
}
