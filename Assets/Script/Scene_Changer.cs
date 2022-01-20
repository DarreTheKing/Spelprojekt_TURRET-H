using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField]
    int sceneIndex; //g�r s� att man kan �ndra vilken scen den ska g� till i indexen

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RestartLevel(sceneIndex); //n�r knappen trycks p� s� f�rs man till scenen man har skrivit i scen indexen
    }

    public void RestartLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); //detta laddar scenen man f�rts till.
    }


}



