using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().OnReset += ObjectDestroyON;
    }

    private void OnDestroy()
    {
        FindObjectOfType<GameManager>().OnReset -= ObjectDestroyON;
    }
    void ObjectDestroyON() //リセットボタンを押すとオブジェクトが消えます
    {
        Destroy(this.gameObject);
    }
}
