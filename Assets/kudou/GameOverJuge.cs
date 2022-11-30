using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverJuge : MonoBehaviour
{
    int teamNum;

    [SerializeField,Header("桃太郎オブジェクトについているTag")] string _charaTagName;
    
    [SerializeField,Header("GameOver時に出すCanvas")] GameObject _gameOverCanvas;
    [SerializeField, Header("GameClear時に出すCanvas")] GameObject _gameClearCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameOverCanvas.SetActive(false);
        _gameClearCanvas.SetActive(false);
        
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(_charaTagName))
        {
            if (collision.gameObject.GetComponent<Momotarou>() != null)
            {
                teamNum = collision.gameObject.GetComponent<Momotarou>().AnimalCount;
                TeamCompleteJuge();　//トリ・サル・イヌがそろっているかの判定を行う  
            }
        }
    }
    void TeamCompleteJuge()
    {
        if (teamNum == 3)　//ゲームクリアのキャンバス表示をする(リザルト画面)
        {
            _gameClearCanvas.SetActive(true);
            FindObjectOfType<GameManager>().NewHighScore();
        }
        else　//ゲームオーバーのキャンバス表示をする
        {
            _gameOverCanvas.SetActive(true);
        }
    }
}
