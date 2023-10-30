using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    Image _panal;

    bool _paused;
    void Start()
    {
        _panal = GetComponentInChildren<Image>();
        _panal.gameObject.SetActive(false);
        _paused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_paused)
                PauseGame();
            else
                Resume();
        }
    }

    public void PauseGame()
    {
        _paused= true;
        OpenMenu();
        Time.timeScale = 0;

    }

    private void OpenMenu()
    {
        _panal.gameObject.SetActive(true);
    }

    public void Resume()
    {
        _paused = false;
        _panal.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
