using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("足場のプレハブ")] GameObject _go;
    [SerializeField, Header("足場を生成する間隔")] float _interval;
    [SerializeField, Header("インクの最大容量")] float _maxinkValue;
    float _inkValue;
    float _timer;
    private void Awake()
    {
        FindObjectOfType<GameManager>().OnReset += Inkrefill;
    }
    void Start()
    {
        _inkValue = _maxinkValue;
        _timer = _interval;
    }

    void Update()
    {
        Vector3 mouseposition = Input.mousePosition;
        mouseposition.z = 10;
        Vector3 target = Camera.main.ScreenToWorldPoint(mouseposition);
        _timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && _timer > _interval && _inkValue > 0)
        {
            Instantiate(_go, target, Quaternion.identity);
            _timer = 0;
            _inkValue--;
        }
    }
    void Inkrefill()
    {
        _inkValue = _maxinkValue;
    }
}
