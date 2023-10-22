using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  #region Variables

  public static UIManager Instance;
  
  private bool isPaused;

  [Header("Main UI")]
  public GameObject _pauseUi;
  public GameObject _levelCompleteUi;
  public GameObject _gameOverUi;
  
  [Header("Sub UI")]
  public GameObject _baseRestart;
  public GameObject _confirmRestart;
  
  public GameObject _baseReturn;
  public GameObject _confirmReturn;

  private bool isAlive; 
  
  #endregion

  #region Unity Methods

  private void Awake()
  {
    Instance = this;
    isPaused = false;
    
    //Set Pause UI inactive by default
    _pauseUi.SetActive(false);

    isAlive = PlayerManager.Instance.GetPlayer().GetComponent<HealthPoint>();
    
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
    
    
    
    if (!isAlive)
      GameOver();
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
  
  public void LevelComplete()
  {
    //Do Game Over Stuff
    _levelCompleteUi.SetActive(true);
  }

  public void GameOver()
  {
    _gameOverUi.SetActive(true);
    Time.timeScale = 0f;
  }

  public void RestartGame()
  {
    SceneManager.LoadScene(1);
  }

  public void ConfirmRestart()
  {
    _baseRestart.SetActive(false);
    _confirmRestart.SetActive(true);
  }

  public void ReturnToTitle()
  {
    SceneManager.LoadScene(0);
  }

  public void Return()
  {
    if (_confirmRestart.activeSelf)
    {
      _confirmRestart.SetActive(false);
      _baseRestart.SetActive(true);
    }
    else if (_confirmReturn.activeSelf)
    {
      _confirmReturn.SetActive(false);
      _baseReturn.SetActive(true);
    }
  }

  #endregion
  
  #region Shorcuts

  private bool KeyPress(KeyCode kc)
  {
    return Input.GetKeyDown(kc);
  }

  #endregion
}
