using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("‘«ê‚ÌƒvƒŒƒnƒu")] GameObject _go;
    [SerializeField, Header("‘«ê‚ğ¶¬‚·‚éŠÔŠu")] float _interval;
    float _timer;
    void Start()
    {
        _timer = _interval;
    }

    void Update()
    {
        Vector3 mouseposition = Input.mousePosition;
        mouseposition.z = 10;
        Vector3 target = Camera.main.ScreenToWorldPoint(mouseposition);
        _timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && _timer > _interval)
        {
            Instantiate(_go, target, Quaternion.identity);
            _timer = 0;
        }
    }
}
