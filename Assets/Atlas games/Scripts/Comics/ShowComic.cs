using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowComic : MonoBehaviour
{
    [Header("Refrences (Be to be changed)")]
    public Comics comics;
    public GameObject UI;
    public GameObject blur;
    public GameObject archerManager;
    private Scene scene;
    GameObject newComicClone;
    public float timer;
    public GameObject[] menuParts;

    public static bool isComicOn = false;
    public static bool isComicOff2 = false;

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
        ResetTutorialFlags();
    }

    public void Update()
    {
        timer += Time.deltaTime;

        for (int i = 0; i < comics.infoT.Length; i++)
        {
            int levelRef = comics.infoT[i].LevelNumber;
            var tutorialObj = comics.infoT[i].ComicPrefab;
            int delayTime = (int)comics.infoT[i].Delay;
            var modelRef = comics.infoT[i].Model.ToString();
            var partRef = comics.infoT[i].MenuPart.ToString();

            // ================= InGame Tutorials =================
            if (modelRef == "InGame" && scene.name == "Playing atlas")
            {
                if (levelRef == GlobalValue.levelPlaying && isComicOn == false)
                {
                    if (timer > delayTime)
                    {
                        newComicClone = Instantiate(tutorialObj, transform.position, Quaternion.identity);
                        UI.transform.localScale = new Vector2(2, 2);
                        archerManager.SetActive(false);
                        blur.SetActive(true);

                        isComicOn = true;
                    }
                }
                else if (isComicOff2 == false && buttonCheck.press)
                {
                    Destroy(newComicClone, 0.1f);
                    Time.timeScale = 1;
                    UI.transform.localScale = new Vector2(1, 1);
                    archerManager.SetActive(true);
                    blur.SetActive(false);

                    isComicOff2 = true;
                    buttonCheck.press = false;
                }
            }
            // ================= InMenu Tutorials =================
            else if (modelRef == "InMenu" && scene.name == "Menu atlas Test")
            {
                string tutorialKey = "tutorialMenu_" + partRef;

                if (PlayerPrefs.GetInt(tutorialKey, 0) == 0)
                {
                    if (partRef == GlobalValue.menuPart && timer > delayTime)
                    {
                        newComicClone = Instantiate(tutorialObj, transform.position, Quaternion.identity);

                        PlayerPrefs.SetInt(tutorialKey, 1);
                        PlayerPrefs.Save();
                    }
                }

                if (buttonCheck.press)
                {
                    Destroy(newComicClone, 0.1f);
                    buttonCheck.press = false;
                }
            }
        }
    }

    /// <summary>
    /// Reset tutorial states when a new scene or level starts
    /// </summary>
    private void ResetTutorialFlags()
    {
        isComicOn = false;
        isComicOff2 = false;
        timer = 0f;
    }
}
