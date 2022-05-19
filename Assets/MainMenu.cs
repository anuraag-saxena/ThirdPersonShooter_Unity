using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;


public class MainMenu : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void res();

    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenuGame()
    {
        res();
    }

    public void Resume() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject canvasMenu = GameObject.Find("Player/Pause");
        canvasMenu.SetActive(false);
    }

}
