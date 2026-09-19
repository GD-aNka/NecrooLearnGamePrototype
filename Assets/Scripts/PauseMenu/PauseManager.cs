using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false;
    private bool continuePressed = false;

    private void Update()
    {
        Debug.Log(continuePressed);
        if (inputManager.isPausePressed() && !isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;


        }
        else if ((inputManager.isPausePressed() || continuePressed) && isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            continuePressed = false;
            isPaused = false;

        }
    }

    public void ContinueButton()
    {
        
        continuePressed = true;
    }
    public void ExitButton()

    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}

