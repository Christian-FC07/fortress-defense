using UnityEngine;

public class ComicMusicPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioClip ComicMusic;
    AudioSource ComicAudioSource;
    void Start()
    {
        GlobalValue.isMusic = !GlobalValue.isMusic;


    }

    public void StartMusic()
    {
        ComicAudioSource.clip = ComicMusic;
        ComicAudioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
