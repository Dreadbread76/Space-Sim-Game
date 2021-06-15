using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject pausePanel;
    private bool isPaused;

   
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuActive();
        }
    }

    public void PauseMenuActive()
    {
        
        isPaused = !isPaused;
        Debug.Log(isPaused);
        if (isPaused)
        {

            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            pausePanel.SetActive(true);
            
        }
        else
        {
           
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
        }
    }
    
}
