using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class showTutorial : MonoBehaviour
{
    [Header("Refrences (Be to be changed)")]
    public tutorials tutorials;
    public GameObject UI;
    public GameObject blur;
    public GameObject archerManager;
    private Scene scene;
    GameObject newTutorialCLone;
    public float timer;
    public GameObject[] menuParts;

    public static bool isTutorialOn = false;
    public static bool isTutorialOn2 = false;
    public static bool isTutorialoff2 = false;

    Dictionary<int, GameObject> levelCheck = new Dictionary<int, GameObject>()
    {
        //{1, tutorials.infoT[1].TutorialPrefab},
    };

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
        ResetTutorialFlags();
    }

    public void Update()
    {
        timer += Time.deltaTime;

        for (int i = 0; i < 50; i++)
        {
            int levelRef = tutorials.infoT[i].LevelNumber;
            var tutorialObj = tutorials.infoT[i].TutorialPrefab;
            int delayTime = (int)tutorials.infoT[i].Delay;
            var modelRef = tutorials.infoT[i].Model.ToString();
            var partRef = tutorials.infoT[i].MenuPart.ToString();

            if (modelRef == "InGame" && scene.name == "Playing atlas")
            {
                if (levelRef == GlobalValue.levelPlaying && isTutorialOn2 == false)
                {
                    if (timer > delayTime)
                    {
                        newTutorialCLone = Instantiate(tutorialObj, transform.position, Quaternion.identity);
                        UI.transform.localScale = new Vector2(2, 2);
                        archerManager.SetActive(false);
                        blur.SetActive(true);

                        // run only once
                        isTutorialOn2 = true;
                    }
                }
                else if (isTutorialoff2 == false && buttonCheck.press)
                {
                    Destroy(newTutorialCLone, 0.1f);
                    Time.timeScale = 1;
                    UI.transform.localScale = new Vector2(1, 1);
                    archerManager.SetActive(true);
                    blur.SetActive(false);

                    // run only once
                    isTutorialoff2 = true;
                    buttonCheck.press = false;
                }
            }
            else if (modelRef == "InMenu" && scene.name == "Menu atlas Test")
            {
                if (partRef == GlobalValue.menuPart && isTutorialOn == false)
                {
                    if (timer > delayTime)
                    {
                        newTutorialCLone = Instantiate(tutorialObj, transform.position, Quaternion.identity);

                        // run only once
                        isTutorialOn = true;
                    }
                }
                else if (buttonCheck.press)
                {
                    Destroy(newTutorialCLone, 0.1f);

                    buttonCheck.press = false;
                }

                PlayerPrefs.SetInt("tutorialMenu", 1);
                PlayerPrefs.Save();
            }
        }
    }

    /// <summary>
    /// Reset tutorial states when a new scene or level starts
    /// </summary>
    private void ResetTutorialFlags()
    {
        isTutorialOn = false;
        isTutorialOn2 = false;
        isTutorialoff2 = false;
        timer = 0f;
    }
}
