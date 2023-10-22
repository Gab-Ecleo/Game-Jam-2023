using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  #region Variables

  public static UIManager Instance;
  
  private bool isPaused;

  public GameObject _pauseUi;

  #endregion

  #region Unity Methods

  private void Awake()
  {
    Instance = this;
    isPaused = false;
    
    //Set Pause UI inactive by default
    _pauseUi.SetActive(false);
  }

  private void Start()
  {
    Time.timeScale = 1f;
  }

  private void Update()
  {
    if (!isPaused)
    {
      if (KeyPress(KeyCode.Escape) || KeyPress(KeyCode.P))
        PauseGame();
    }
    else if (isPaused)
      if (KeyPress(KeyCode.Escape) || KeyPress(KeyCode.P))
        ResumeGame();
  }

  #endregion

  #region Methods

  public void PauseGame()
  {
    _pauseUi.SetActive(true);
    isPaused = true;
    Time.timeScale = 0f;
  }

  public void ResumeGame()
  {
    _pauseUi.SetActive(false);
    isPaused = false;
    Time.timeScale = 1f;
  }

  #endregion
  
  #region Shorcuts

  private bool KeyPress(KeyCode kc)
  {
    return Input.GetKeyDown(kc);
  }

  #endregion
}
