using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("‘«ê‚ÌƒvƒŒƒnƒu")] GameObject _go;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mouseposition = Input.mousePosition;
        mouseposition.z = 10;
        Vector3 target = Camera.main.ScreenToWorldPoint(mouseposition);
        if (Input.GetMouseButton(0))
        {
            Instantiate(_go, target, Quaternion.identity);
        }
    }
}
