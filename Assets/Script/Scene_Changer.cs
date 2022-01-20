using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField]
    int sceneIndex; //gör så att man kan ändra vilken scen den ska gå till i indexen

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RestartLevel(sceneIndex); //när knappen trycks på så förs man till scenen man har skrivit i scen indexen
    }

    public void RestartLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); //detta laddar scenen man förts till.
    }


}



