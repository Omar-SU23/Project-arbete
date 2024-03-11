using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderbord : MonoBehaviour
{
    public int score = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Addscore()
    {
        score += Random.Range(100, 500);
    }
}
