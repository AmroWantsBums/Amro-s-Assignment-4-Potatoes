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
    // Start is called before the first frame update
    void Start()
    {
        SpawnLocation = GameObject.Find("SpawnLocation").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        bool GameStarted = false;
        if (!GameStarted)
        {
            float interval = 0;
            if (interval < 1)
            {
                interval = interval + Time.deltaTime;
            }
            else
            {
                Seconds--;
                if (Seconds == 0)
                {
                    GameStarted = true;
                    CountdownText.text = $"{Seconds}";
                    RandomNumber();
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
