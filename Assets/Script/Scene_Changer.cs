using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{
    [SerializeField]
    int sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RestartLevel(sceneIndex); //n�r knappen trycks p� s� f�rs man till scenen man har skrivit i scen - Darian
    }

    public void RestartLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); //detta laddar scenen man f�rts till - Darian
    }
    public void Replay()
    {
        SceneManager.LoadScene("Start");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_menu_Scene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
