using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    GameObject sumomo;
    // Start is called before the first frame update
    void Start()
    {
        sumomo = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sumomo.transform.position = new Vector3(0, 6, 0);
        }
    }
}
