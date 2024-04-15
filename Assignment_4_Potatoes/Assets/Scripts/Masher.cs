using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Masher : MonoBehaviour
{
    private float Speed = 14f;
    private bool Mashing = false;
    private Vector2 ResetPosition;
    public int Lives = 3;
    public GameObject[] HealthSprites;
    public AudioSource SquishSource;
    public PotatoSpawner potatoSpawner;
    public Score score;
    public GameObject DeathCanvas;
    public bool GameOver = false;
    public TextMeshProUGUI FinalScore;
    public AudioSource BgAudio;
    public AudioSource BombAudio;

    // Start is called before the first frame update
    void Start()
    {
        ResetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (potatoSpawner.GameStarted)
        {
            if (Input.GetKeyDown("space"))
            {
                Mashing = true;
            }
            if (Mashing)
            {
                transform.Translate(new Vector2(0, -4) * Speed * Time.deltaTime);
            }
            if (!Mashing)
            {
                float distance = Vector2.Distance(transform.position, ResetPosition);
                if (distance > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, ResetPosition, Speed * Time.deltaTime);
                }
            }
            if (Lives == 2)
            {
                Destroy(HealthSprites[2]);
            }
            if (Lives == 1)
            {
                Destroy(HealthSprites[1]);
            }
        }        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Plane")
        {
            Mashing = false;
        }

        if (col.gameObject.CompareTag("Potato"))
        {
            Destroy(col.gameObject);
            SquishSource.Play();
            Mashing = false;
            score.CurrentScore = score.CurrentScore + 10;
        }

        if (col.gameObject.CompareTag("Bomb"))
        {
            GameOver = true;
            BombAudio.Play();
            Time.timeScale = 0;
            StartCoroutine(DeathLoad());
        }
    }

    IEnumerator DeathLoad()
    {
        BgAudio.Stop();
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < 2.5f)
        {
            yield return null;
        }
        DeathCanvas.SetActive(true);
        FinalScore.text = $"{score.CurrentScore}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
