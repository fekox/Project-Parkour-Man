using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

/// <summary>
/// Manage all input of the UI.
/// </summary>
public class UIInputManger : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private PauseMenu pauseMenu;

    [SerializeField] private GameObject resumeButton;

    UIInputs action;

    /// <summary>
    /// The action is assigned the UIInput.
    /// </summary>
    private void Awake()
    {
        action = new UIInputs();
    }

    /// <summary>
    /// The component is assigned to the pause menu.
    /// The action is set.
    /// </summary>
    void Start()
    {
        pauseMenu = GetComponent<PauseMenu>();

        action.UI.Pause.performed += _ => IsPaused();
    }

    /// <summary>
    /// If the book of the pause menu is set to true, 
    /// the pause is activated, otherwise it is deactivated.
    /// </summary>
    private void IsPaused() 
    {
        if (pauseMenu.gamePause == true) 
        {
            ResumeGame();
            EventSystem.current.SetSelectedGameObject(null);
        }

        else 
        {
            PauseGame();
            EventSystem.current.SetSelectedGameObject(resumeButton);
        }
    }

    /// <summary>
    /// Action is active.
    /// </summary>
    public void OnEnable() 
    {
        action.Enable();
    }

    /// <summary>
    /// Action is disable.
    /// </summary>
    private void OnDisable()
    {
        action.Disable();
    }

    /// <summary>
    /// The game is paused.
    /// </summary>
    public void PauseGame() 
    {
        pauseMenu.Pause();
    }

    /// <summary>
    /// The game is not paused.
    /// </summary>
    public void ResumeGame() 
    {
        pauseMenu.Resume();
    }
}