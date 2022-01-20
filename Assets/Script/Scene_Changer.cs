using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{
    [SerializeField]
    int sceneIndex; //g�r s� att man kan �ndra vilken scen den ska g� till i indexen

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RestartLevel(sceneIndex); //n�r knappen trycks p� s� f�rs man till scenen man har skrivit i scen indexen
    }
    public void Replay()
    {
        SceneManager.LoadScene("Start");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Main_menu_Scene");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void RestartLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); //detta laddar scenen man f�rts till.
    }


}



