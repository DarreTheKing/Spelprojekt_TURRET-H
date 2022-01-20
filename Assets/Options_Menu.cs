using UnityEngine.Audio;
using UnityEngine;

public class Options_Menu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public void SetVolume(float Volume)
    {
        mainMixer.SetFloat("Volume", Volume); //gör så att man kan ändra volymen - Darian
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
