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
    public showTutorial tutorialManager;
    public float tutorialDelayAfterComic = 2f;


    public static bool isComicOn = false;
    public static bool isComicOff2 = false;
    public  bool isComicEnded = false;

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
        ResetComicsFlags();
        isComicEnded=false;
    }

    private bool tutorialTimerActive = false;
    private float tutorialTimer = 0f;
    private bool tutorialSpawned = false; // برای جلوگیری از لود چندباره

    public void Update()
    {
        timer += Time.deltaTime;

        // 🎬 1. Comic را لود کن
        if (!isComicOn)
        {
            for (int i = 0; i < comics.infoT.Length; i++)
            {
                int levelRef = comics.infoT[i].LevelNumber;
                var comicObj = comics.infoT[i].ComicPrefab;
                int delayTime = (int)comics.infoT[i].Delay;
                var modelRef = comics.infoT[i].Model.ToString();

                if (modelRef == "InGame" && scene.name == "Playing atlas")
                {
                    if (levelRef == GlobalValue.levelPlaying && timer > delayTime)
                    {
                        newComicClone = Instantiate(comicObj, transform.position, Quaternion.identity);
                        UI.transform.localScale = new Vector2(2, 2);
                        archerManager.SetActive(false);
                        blur.SetActive(true);
                        isComicOn = true;
                        Debug.Log("🎞 Comic spawned");
                    }
                }
            }
        }

        // 🧩 2. وقتی دکمه‌ی Comic زده شد => Comic بسته شود
        if (isComicOn && buttonCheck.Comicpress)
        {
            if (newComicClone != null)
                Destroy(newComicClone, 0.1f);

            UI.transform.localScale = new Vector2(1, 1);
            archerManager.SetActive(true);
            blur.SetActive(false);

            isComicOn = false;
            isComicOff2 = true;
            isComicEnded = true;
            buttonCheck.Comicpress = false;

            // فعال‌سازی تایمر برای Tutorial
            tutorialTimerActive = true;
            tutorialTimer = 0f;

            Debug.Log("✅ Comic closed, tutorial timer started");
        }

        // ⏳ 3. صبر کن تا تایمر بگذره و سپس Tutorial را لود کن
        if (tutorialTimerActive && !tutorialSpawned)
        {
            tutorialTimer += Time.deltaTime;
            if (tutorialTimer > tutorialDelayAfterComic)
            {
                // لود Tutorial
                for (int i = 0; i < comics.infoT.Length; i++)
                {
                    int levelRef = comics.infoT[i].LevelNumber;
                    var tutorialObj = comics.infoT[i].ComicPrefab; // فرض بر این است که هر Comic، Tutorial متناظر دارد
                    var modelRef = comics.infoT[i].Model.ToString();

                    if (modelRef == "InGame" && scene.name == "Playing atlas")
                    {
                        if (levelRef == GlobalValue.levelPlaying && tutorialObj != null)
                        {
                            Instantiate(tutorialObj, transform.position, Quaternion.identity);
                            UI.transform.localScale = new Vector2(2, 2);
                            archerManager.SetActive(false);
                            blur.SetActive(true);
                            tutorialSpawned = true;
                            tutorialTimerActive = false;
                            Debug.Log("🎯 Tutorial spawned after Comic");
                            break;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Reset tutorial states when a new scene or level starts
    /// </summary>
    private void ResetComicsFlags()
    {
        isComicOn = false;
        isComicOff2 = false;
        isComicEnded = false;
        timer = 0f;
    }
}
