using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotatoSpawner : MonoBehaviour
{
    public GameObject Potato;
    public GameObject Bomb;
    private Transform SpawnLocation;
    public TextMeshProUGUI CountdownText;
    private int Seconds = 3;
    public bool GameStarted = false;
    private float Interval;
    public GameObject TextObject;
    public AudioSource BackgroundAudio;
    // Start is called before the first frame update
    void Start()
    {
        SpawnLocation = GameObject.Find("SpawnLocation").GetComponent<Transform>();
        //RandomNumber();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameStarted)
        {
            if (Interval < 1)
            {
                Interval = Interval + Time.deltaTime;
            }
            else
            {
                Seconds--;
                Interval = 0;
                CountdownText.text = $"{Seconds}";
                if (Seconds == 0)
                {
                    GameStarted = true;
                    RandomNumber();
                    BackgroundAudio.Play();
                    TextObject.SetActive(false);
                }
            }
        }
    }

    void RandomNumber()
    {
        int RandomNo = Random.Range(0,6);
        if (RandomNo == 4 || RandomNo == 2)
        {
            StartCoroutine(SpawnBomb());
        }
        else
        {
            StartCoroutine(SpawnPotato());
        }
    }

    IEnumerator SpawnPotato()
    {
        Instantiate(Potato, SpawnLocation.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        RandomNumber();
    }

    IEnumerator SpawnBomb()
    {
        Instantiate(Bomb, SpawnLocation.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        RandomNumber();
    }
}
