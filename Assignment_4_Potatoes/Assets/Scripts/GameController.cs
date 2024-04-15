using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Masher masher;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!masher.GameOver)
        {
            Time.timeScale = Time.timeScale + 0.00005f;
        }
    }
}
