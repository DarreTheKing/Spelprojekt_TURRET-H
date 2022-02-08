using UnityEngine.Audio;
using UnityEngine;

public class Options : MonoBehaviour
{
    public AudioMixer mainMixer; //Skapar en audiomixer - Darian
    public void SetVolume(float Volume)
    {
        mainMixer.SetFloat("Volume", Volume); //g�r s� att man kan �ndra volymen - Darian
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
