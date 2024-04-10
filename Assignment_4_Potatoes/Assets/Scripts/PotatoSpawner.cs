using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoSpawner : MonoBehaviour
{
    public GameObject Potato;
    public GameObject Bomb;
    private Transform SpawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        SpawnLocation = GameObject.Find("SpawnLocation").GetComponent<Transform>();
        RandomNumber();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomNumber()
    {
        int RandomNo = Random.Range(0,5);
        Debug.Log(RandomNo);
        if (RandomNo == 4)
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
