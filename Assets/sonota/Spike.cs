using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] GameObject _spike;
    [SerializeField] float _cooltime;
    [SerializeField] Transform _muzzle;
    float _time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Spike").Length <= 9)
        {
            _time += Time.deltaTime;
            if(_time > _cooltime)
            {
                Instantiate(_spike, _muzzle.position, this.transform.rotation);
                _time = 0;
            }
        }
    }
}
