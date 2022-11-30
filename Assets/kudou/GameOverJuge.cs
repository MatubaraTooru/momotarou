using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverJuge : MonoBehaviour
{
    int teamNum;

    [SerializeField] string _charaTagName;
    
    [SerializeField,Header("GameOveréûÇ…èoÇ∑Canvas")] GameObject _gameOverCanvas;
    [SerializeField, Header("GameClearéûÇ…èoÇ∑Canvas")] GameObject _gameClearCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameOverCanvas.SetActive(false);
        _gameClearCanvas.SetActive(false);
        
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(_charaTagName))
        {
            if (collision.gameObject.GetComponent<Momotarou>() != null)
            {
                teamNum = collision.gameObject.GetComponent<Momotarou>().AnimalCount;
                TeamCompleteJuge();
                FindObjectOfType<GameManager>().NewHighScore();
            }
        }
    }
    void TeamCompleteJuge()
    {
        if (teamNum == 3)
        {
            _gameClearCanvas.SetActive(true);

        }
        else
        {
            _gameOverCanvas.SetActive(true);
        }
    }
}
