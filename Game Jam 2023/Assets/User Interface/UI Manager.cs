using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  #region Variables

  public static UIManager Instance;

  [SerializeField] private GameObject[] _uiObj;
  private bool isPaused;

  #endregion

  #region Unity Methods

  private void Awake()
  {
    Instance = this;
    isPaused = false;

    foreach (GameObject obj in _uiObj)
    {
      Instantiate(obj);
    }
  }

  private void Start()
  {
    //Set Pause UI inactive by default
    _uiObj[1].SetActive(false);
    Time.timeScale = 1f;
  }

  private void Update()
  {
    if (KeyPress(KeyCode.Escape) || KeyPress(KeyCode.P))
      PauseGame();
  }

  #endregion

  #region Methods

  public void PauseGame()
  {
    Debug.Log("Game Paused");
    isPaused = true;
    Time.timeScale = 0f;
    _uiObj[1].SetActive(true);
  }

  public void ResumeGame()
  {
    Debug.Log("Game Resumed");
    isPaused = false;
    Time.timeScale = 1f;
    _uiObj[1].SetActive(false);
  }

  #endregion
  
  #region Shorcuts

  private bool KeyPress(KeyCode kc)
  {
    return Input.GetKeyDown(kc);
  }

  #endregion
}
