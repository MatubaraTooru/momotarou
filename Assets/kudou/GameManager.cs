using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class HighScore
{
    public float _score;

}
public class GameManager : MonoBehaviour
{
    event Action Reset;
    float _timer;
    [SerializeField] Text _timerText;
    bool isResult = false;
    
    public Action OnReset { get => Reset; set => Reset = value; }

    float _nowScore;
    float _highScore;

    HighScore scoreSave = new HighScore();

    [SerializeField] Text _highScoreText;
    [SerializeField] Text _nowScoreText;

    [SerializeField,Header("HighScore�̐������ς�鑬�x")] float scoreChangeSpeed;

    Animator _textAnim = default;
    // Start is called before the first frame update
    void Start()
    {
        scoreSave = HighScoreSave.OnLoad(scoreSave);
        _timer = 0;�@
        _highScore = scoreSave._score;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isResult)
        {
            _nowScore = _timer;
            _highScoreText.text = $"{_highScore.ToString("F2")}";
            _nowScoreText.text = $"{_nowScore.ToString("F2")}";
            if(_nowScore == _highScore)
            {
                _textAnim = GameObject.Find("HighScoreText").GetComponent<Animator>();
                //DoTween�Ńn�C�X�R�A���ς��I��������n�C�X�R�A�̃e�L�X�g�̃T�C�Y���A�j���[�V�����ŕς���
                StartCoroutine(HighScoreSize());
            }
        }
        else
        {
            _timer += Time.deltaTime;
            _timerText.text = _timer.ToString("F2");
        }
    }

    public void DownResetButton()
    {
        //Reset�̒��g���󂶂�Ȃ��Ƃ��q���������̃f���Q�[�g���Ă�
        if (Reset != null)
        {
            Reset.Invoke();
        }
    }

    public void NewHighScore() //���U���g��ʂ�\���������ɍs��
    {
        isResult = true;
        if (_nowScore < _highScore)
        {
            scoreSave._score = _nowScore;
            HighScoreSave.OnSave(scoreSave);
            
            ScoreChangeValue();
        }
    }
    //�X�R�A���X�V�������Ƀn�C�X�R�A�̃e�L�X�g�\����ŏ��X�ɕς��Ă���
    void ScoreChangeValue()
    {
        DOTween.To(() => _highScore, x => _highScore = x, _nowScore, scoreChangeSpeed);
    }

    IEnumerator HighScoreSize()
    {
        yield return new WaitForSeconds(0.5f);
        _textAnim.Play("HighScoreSize");
    }
}
