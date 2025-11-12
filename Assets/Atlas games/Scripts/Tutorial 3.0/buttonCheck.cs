using UnityEngine;

public class buttonCheck : MonoBehaviour
{
    public static bool press = false;
    public static bool press2 = false;
    public CoTu_Timer Timer;
    public ComicMusicPlayer MusicController;
    public void buttonPress()
    {
        press = true;
        press2 = true;
        Debug.Log("pressed");
        Time.timeScale = 1;
    }
    public static bool Comicpress = false;
    public static bool Comicpress2 = false;

    public void ComicButtonPress()
    {
        MusicController = GameObject.FindAnyObjectByType<ComicMusicPlayer>();
        MusicController.StartGameMusic();
        Timer = GameObject.FindAnyObjectByType<CoTu_Timer>();
        Comicpress = true;
        Comicpress2 = true;
        Debug.Log("Comic pressed");
        Timer.comicClosed = true;
        Timer.isCounting = true;
        Debug.Log("Vars Changed");
        Time.timeScale = 1;
    }
}
