using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    PauseAction action;
    public bool paused;

    public GameObject menu;

    //get reference to pause action
    private void Awake()
    {
        action = new PauseAction();

    }

    //make active
    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    //bind enable and disable to esc key
    private void Start()
    {
        //when the function PauseGame in Pause action map is excecuted, do the method
        action.Pause.PauseGame.performed += _ => DeterminePause();
    }

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        DeterminePause();
    //    }
    //}

    private void DeterminePause()
    {
        if (paused)
        {
            ResumeGame();
        } else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
        menu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
        menu.SetActive(false);

    }

}
