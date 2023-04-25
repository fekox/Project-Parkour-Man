using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputManger : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private PauseMenu pauseMenu;

    UIInputs action;

    private void Awake()
    {
        action = new UIInputs();
    }

    void Start()
    {
        pauseMenu = GetComponent<PauseMenu>();

        action.UI.Pause.performed += _ => IsPaused();
    }

    private void IsPaused() 
    {
        if (pauseMenu.gamePause == true) 
        {
            ResumeGame();
        }

        else 
        {
            PauseGame();
        }
    }

    public void OnLook(InputValue inputValue) 
    {
    
    }

    public void OnSelect() 
    {
        
    }

    public void OnEnable() 
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    public void PauseGame() 
    {
        pauseMenu.Pause();
    }

    public void ResumeGame() 
    {
        pauseMenu.Resume();
    }

}
