using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVersionOne()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("FunkyMusic");
        Time.timeScale = 1;
    }

    public void PlayVersionTwo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Dramatic Music");
        Time.timeScale = 1;
    }
}
