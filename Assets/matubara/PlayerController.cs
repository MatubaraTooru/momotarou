using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("足場のプレハブ")] GameObject _go;
    [SerializeField, Header("足場を生成する間隔")] float _interval;
    [SerializeField, Header("インクの最大容量")] float _maxinkValue;
    [SerializeField, Header("インクのゲージ")] Slider _inkSlider;
    float _timer;
    private void Awake()
    {
        FindObjectOfType<GameManager>().OnReset += Inkrefill;
    }
    void Start()
    {
        _inkSlider.maxValue = _maxinkValue;
        _inkSlider.value = _maxinkValue;
        _timer = _interval;
    }

    void Update()
    {
        Vector3 mouseposition = Input.mousePosition;
        mouseposition.z = 10;
        Vector3 target = Camera.main.ScreenToWorldPoint(mouseposition);
        _timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && _timer > _interval && _inkSlider.value > 0)
        {
            Instantiate(_go, target, Quaternion.identity);
            _timer = 0;
            _inkSlider.value--;
        }
    }
    void Inkrefill()
    {
        _inkSlider.value = _maxinkValue;
    }
}
