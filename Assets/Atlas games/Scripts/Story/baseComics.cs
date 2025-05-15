using UnityEngine;

public class baseComics : MonoBehaviour
{
    public GameObject comics;
    GameObject comicClone;
    bool isComicOff = false;

    void Update()
    {
        if(Level.isComic && isComicOff)
        {
            Invoke("comicss", 0.1f);
        }
        else if(buttonCheck.press2)
        {
            Destroy(comicClone, 0.1f);
            Time.timeScale = 1;
        }
    }

    void comicss()
    {
        comicClone = Instantiate(comics, transform.position, Quaternion.identity);
            Time.timeScale = 0;
            isComicOff = false;
            Debug.Log("yppppppppp");
    }
}
