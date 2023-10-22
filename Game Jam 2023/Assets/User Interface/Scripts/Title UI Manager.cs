using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _credits;
    [SerializeField] private GameObject _confirmExit;
    [SerializeField] private GameObject _mainScreen;

    #endregion

    #region Methods

    public void StartGame()
    {
        //Load Game Scene
        _mainScreen.SetActive(true);
    }

    public void LoadCredits()
    {
        _mainScreen.SetActive(false);
        _credits.SetActive(true);
    }
    
    public void GoBack()
    {
        _credits.SetActive(false);
        _confirmExit.SetActive(false);
        
        _mainScreen.SetActive(true);
    }

    public void ConfirmExit()
    {
        _confirmExit.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application closed");
    }
    
    #endregion
}
