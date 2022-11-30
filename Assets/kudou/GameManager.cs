using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GameManager : MonoBehaviour
{
    event Action Reset;
    float _timer;
    [SerializeField] Text _timerText;
    bool isGame;
    public bool IsGame { get => isGame; set => isGame = value; }
    public Action OnReset { get => Reset; set => Reset = value; }

    
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _timerText.text = _timer.ToString("F2");
    }

    public void DownResetButton()
    {
        if (Reset != null)
        {
            Reset.Invoke();
        }
    }
}
