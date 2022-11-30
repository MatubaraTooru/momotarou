using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] GameObject _open;
    [SerializeField] GameObject _close;
    public void SceneSwitch(string s)
    {
        SceneManager.LoadScene(s);
    }
    public void SetActive()
    {
        _open.SetActive(true);
        _close.SetActive(false);
    }
}

