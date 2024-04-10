using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Masher : MonoBehaviour
{
    private float Speed = 14f;
    public bool Mashing = false;
    private Vector2 ResetPosition;
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
    }
}
