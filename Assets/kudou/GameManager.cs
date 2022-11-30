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

    [SerializeField]float _nowScore;
    [SerializeField]float _highScore;

    HighScore scoreSave = new HighScore();

    [SerializeField] Text _highScoreText;
    [SerializeField] Text _nowScoreText;

    [SerializeField] float scoreChangeSpeed;

    [SerializeField] Animator _textAnim;
    // Start is called before the first frame update
    void Start()
    {
        scoreSave = HighScoreSave.OnLoad(scoreSave);
        _timer = 0;
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
        if (Reset != null)
        {
            Reset.Invoke();
        }
    }

    public void NewHighScore()
    {
        isResult = true;
        if (_nowScore < _highScore)
        {
            scoreSave._score = _nowScore;
            HighScoreSave.OnSave(scoreSave);
            
            ScoreChangeValue();
        }
    }

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
