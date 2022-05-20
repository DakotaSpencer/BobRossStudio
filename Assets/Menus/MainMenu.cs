using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadSave()
    {
        Debug.Log("Loading Scene");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}
