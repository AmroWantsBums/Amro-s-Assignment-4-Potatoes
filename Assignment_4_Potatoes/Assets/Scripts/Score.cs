using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreTxt;
    public float CurrentScore;
    public PotatoSpawner potatoSpawner;
    private float Interval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (potatoSpawner.GameStarted)
        {
            if (Interval < 0.1)
            {
                Interval = Interval + Time.deltaTime;
            }
            else
            {
                Interval = 0;
                CurrentScore++;
                ScoreTxt.text = $"Score : {CurrentScore}";

            }
        }
    }
}
