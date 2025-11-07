using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowComic : MonoBehaviour
{
    [Header("Refrences (Be to be changed)")]
    public Comics Comics;
    public GameObject UI;
    public GameObject blur;
    public GameObject archerManager;
    private Scene scene;
    GameObject newComicClone;
    public float timer;
    public GameObject[] menuParts;
    public CoTu_Timer Timer;
    //public showTutorial showTutorial;


    public static bool isComicOn = false;
    public static bool isComicOff2 = false;

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
        ResetComicsFlags();
    }

    public void Update()
    {
        timer += Time.deltaTime;

        for (int i = 0; i < Comics.infoT.Length; i++)
        {
            int levelRef = Comics.infoT[i].LevelNumber;
            var comicObj = Comics.infoT[i].ComicPrefab;
            int delayTime = (int)Comics.infoT[i].Delay;
            var modelRef = Comics.infoT[i].Model.ToString();
            var partRef = Comics.infoT[i].MenuPart.ToString();

            // ================= InGame Tutorials =================
            if (modelRef == "InGame" && scene.name == "Playing atlas")
            {
                if (levelRef == GlobalValue.levelPlaying && isComicOn == false)
                {
                    if (timer > delayTime)
                    {
                        newComicClone = Instantiate(comicObj, transform.position, Quaternion.identity);
                        UI.transform.localScale = new Vector2(2, 2);
                        archerManager.SetActive(false);
                        blur.SetActive(true);

                        isComicOn = true;
                    }

                    // فقط قسمت مربوط به فشردن دکمه را جایگزین کن (باقی کد شما بدون تغییر)
                    if (buttonCheck.Comicpress)
                    {
                        Destroy(newComicClone);
                        buttonCheck.Comicpress = false;

                    }


                }
                else if (isComicOff2 == false && buttonCheck.Comicpress)
                {
                    Destroy(newComicClone, 0.1f);
                    Time.timeScale = 1;
                    UI.transform.localScale = new Vector2(1, 1);
                    archerManager.SetActive(true);
                    blur.SetActive(false);

                    isComicOff2 = true;
                    buttonCheck.Comicpress = false;
                }
            }
            // ================= InMenu Tutorials =================
            //else if (modelRef == "InMenu" && scene.name == "Menu atlas Test")
            //{
            //    string tutorialKey = "tutorialMenu_" + partRef;

            //    if (PlayerPrefs.GetInt(tutorialKey, 0) == 0)
            //    {
            //        if (partRef == GlobalValue.menuPart && timer > delayTime)
            //        {
            //            newComicClone = Instantiate(comicObj, transform.position, Quaternion.identity);

            //            PlayerPrefs.SetInt(tutorialKey, 1);
            //            PlayerPrefs.Save();
            //        }
            //    }

            //    if (ComicbuttonCheck.press)
            //    {
            //        Destroy(newComicClone);
            //        ComicbuttonCheck.press = false;
            //    }
            //}
        }
    }

    /// <summary>
    /// Reset tutorial states when a new scene or level starts
    /// </summary>
    private void ResetComicsFlags()
    {
        isComicOn = false;
        isComicOff2 = false;
        timer = 0f;
    }
}
