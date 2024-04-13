using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Masher : MonoBehaviour
{
    private float Speed = 14f;
    private bool Mashing = false;
    private Vector2 ResetPosition;
    public int Lives = 3;
    public GameObject[] HealthSprites;
    // Start is called before the first frame update
    void Start()
    {
        ResetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
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
            transform.position = Vector2.MoveTowards(transform.position, ResetPosition, Speed * Time.deltaTime);
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Plane")
        {
            Mashing = false;
        }

        if (col.gameObject.CompareTag("Potato"))
        {
            Destroy(col.gameObject);
            Mashing = false;
        }

        if (col.gameObject.CompareTag("Bomb"))
        {
            Lives--;
        }
    }

    IEnumerator RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        yield return null;
    }
}
