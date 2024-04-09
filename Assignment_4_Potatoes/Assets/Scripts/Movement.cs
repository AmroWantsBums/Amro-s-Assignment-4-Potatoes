using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rb.velocity = new Vector2(2f, 0);
    }
}
