using UnityEngine;

public class levelChanges2 : MonoBehaviour
{
    //public GameObject GameLevelSetupObj;
    //GameLevelSetup GameLevelSetupScr;

    //public LevelWave[] Levels;
    public GameObject[] spawnPoints;
    public GameObject[] upgradePoints;
    public GameObject[] tutorials;
    public GameObject volumeEffects;
    public GameObject gameUI;

    void Start()
    {
        //GameLevelSetupScr = GameLevelSetupObj.GetComponent<GameLevelSetup>();
        if(GlobalValue.levelPlaying < 1000)
        {
            wplayMusic();
        }
        else // its equivalent to 1000 or greather
        {
            endlessPlayMusic();
        }

        //for(int i = 0; i < tutorials.Length; i++)
        //{
            //spawnPoints[i].SetActive(false);
            //upgradePoints[i].SetActive(false);
        //}
    }

    void Update()
    {
       //Levels = GameLevelSetupScr.levelWaves.ToArray();
       int levelNum = (int)(GlobalValue.levelPlaying);

       if(Input.GetKey("p"))
           {
               SoundManager.Instance.PauseMusic(true);
               Debug.Log("p is pressed");
           }

        switch(levelNum)
        {
            case 1:
                spawnPoints[1].SetActive(false);
                spawnPoints[2].SetActive(false);
                spawnPoints[3].SetActive(false);
                spawnPoints[4].SetActive(false);
                tutorials[0].SetActive(true);
                break;
            case 2:
                spawnPoints[2].SetActive(false);
                spawnPoints[3].SetActive(false);
                spawnPoints[4].SetActive(false);
                upgradePoints[0].SetActive(false);
                upgradePoints[1].SetActive(false);
                upgradePoints[2].SetActive(false);
                upgradePoints[3].SetActive(false);
                upgradePoints[4].SetActive(false);
                tutorials[1].SetActive(true);
                break;
            case 3:
                spawnPoints[2].SetActive(false);
                spawnPoints[3].SetActive(false);
                spawnPoints[4].SetActive(false);
                tutorials[2].SetActive(true);
                break;
            default:
                spawnPoints[0].SetActive(true);
                spawnPoints[1].SetActive(true);
                spawnPoints[2].SetActive(true);
                spawnPoints[3].SetActive(true);
                spawnPoints[4].SetActive(true);
                upgradePoints[0].SetActive(false);
                upgradePoints[1].SetActive(false);
                upgradePoints[2].SetActive(false);
                upgradePoints[3].SetActive(false);
                upgradePoints[4].SetActive(false);
                break;
        }

        if(TutorialNew.isTutorialOn)
        {
            volumeEffects.SetActive(true);
            gameUI.SetActive(false);
        }
        else
        {
            volumeEffects.SetActive(false);
            gameUI.SetActive(true);
        }
    }

    void wplayMusic()
    {
       SoundManager.PlayMusic(SoundManager.Instance.world[(int)((GlobalValue.levelPlaying - 0.1)/10)]);
       Debug.Log("code is running");      
    }
    
    void endlessPlayMusic()
    {
       SoundManager.PlayMusic(SoundManager.Instance.endlessworld[(int)((GlobalValue.levelPlaying) - 1001)]);    
    }
}
