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
        RestartLevel(sceneIndex); //när knappen trycks på så förs man till scenen man har skrivit i scen - Darian
    }

    public void RestartLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); //detta laddar scenen man förts till - Darian
    }

}
