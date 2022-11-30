using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] GameObject _spike;
    [SerializeField] float _cooltime;
    float _time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Spike").Length <= 0)
        {
            _time += Time.deltaTime;
            if(_time > _cooltime)
            {
                Instantiate(_spike, this.transform.position, this.transform.rotation);
                _time = 0;
            }
        }
    }
}
