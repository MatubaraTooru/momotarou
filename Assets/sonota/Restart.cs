using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    GameObject sumomo;
    Vector3 _basePosition;
    // Start is called before the first frame update
    void Start()
    {
        sumomo = GameObject.FindGameObjectWithTag("momo");
        _basePosition = sumomo.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "momo")
        {
            sumomo.transform.position = _basePosition;
        }
    }
}
