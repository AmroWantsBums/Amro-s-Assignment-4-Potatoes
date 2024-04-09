using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Masher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Mash();
        }
    }

    void Mash()
    {
        transform.position = new Vector2(0, -4);
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1f);
        transform.Translate(Vector2.up * Time.deltaTime);
    }
}
