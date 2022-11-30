using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverJuge : MonoBehaviour
{
    int teamNum;

    [SerializeField,Header("�����Y�I�u�W�F�N�g�ɂ��Ă���Tag")] string _charaTagName;
    
    [SerializeField,Header("GameOver���ɏo��Canvas")] GameObject _gameOverCanvas;
    [SerializeField, Header("GameClear���ɏo��Canvas")] GameObject _gameClearCanvas;
    
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
                TeamCompleteJuge();�@//�g���E�T���E�C�k��������Ă��邩�̔�����s��  
            }
        }
    }
    void TeamCompleteJuge()
    {
        if (teamNum == 3)�@//�Q�[���N���A�̃L�����o�X�\��������(���U���g���)
        {
            _gameClearCanvas.SetActive(true);
            FindObjectOfType<GameManager>().NewHighScore();
        }
        else�@//�Q�[���I�[�o�[�̃L�����o�X�\��������
        {
            _gameOverCanvas.SetActive(true);
        }
    }
}
