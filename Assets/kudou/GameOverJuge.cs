using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJuge : MonoBehaviour
{
    int teamNum;

    [SerializeField] string _charaTagName;
    bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(_charaTagName))
        {
            //if (collision.gameObject.GetComponent<>() != null)
            //{
            //    teamNum = collision.gameObject.GetComponent<>();
            //    TeamCompleteJuge();
            //}
        }
    }
    void TeamCompleteJuge()
    {
        if (teamNum == 3)
        {
            isGameOver = true;
        }
        else
        {
            isGameOver = false;
        }
    }
}
