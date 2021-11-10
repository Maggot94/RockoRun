using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private  GameObject GameOverPanel;
    [SerializeField] private GameObject PauseMenu;


    public void ShowHidePause (bool show)
    {
        
      PauseMenu.SetActive(show);
        if (show)
        {
            Time.timeScale = 0;

        } else
        {
            Time.timeScale = 1;

        }
    }

    public void showGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }
    
    public void loadScene(int Scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Scene);
    }
}
