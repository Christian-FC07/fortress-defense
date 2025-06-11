using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class guideBook : MonoBehaviour
{
    private int enemiesChecker = 0;
    public int enemiesAmount = 5;
    public GameObject button;
    public RectTransform bHolder;
    public RectTransform bHolder2;
    public buttonTag buttonScr;
    public Image enemyProf;
    public enemyClasses guideInfo;
    public GameObject lockIcon;
    public GameObject cover;
    public static GameObject lockIconStatic;
    public static GameObject coverStatic;
    public float timer;

    public void Start()
    {
        buttonScr = button.GetComponent<buttonTag>();
        lockIconStatic = lockIcon;
        coverStatic = cover;
    }
    public void Update()
    {
        updateText();
        add();

        timer = Time.deltaTime;

        if(GlobalValue.LevelPass == (int)timer)
        {
            Debug.Log("no");
        }
    }

    public void add()
    {
        if(enemiesChecker < enemiesAmount)
        {
            if(enemiesChecker < 25)
            {
                Instantiate(button, bHolder, false);
            }
            else if(enemiesChecker >= 25)
            {
                Instantiate(button, bHolder2, false);
            }

            enemiesChecker++;
            buttonScr.nTag++;
        }
    }

    public void updateText()
    {
        if(Input.GetKey("k"))
        {
            enemyProf.sprite = guideInfo.enemiesInfo[buttonScr.nTag].EnemyProfile;
        }
        else
        {
            enemyProf.sprite = guideInfo.enemiesInfo[(guideInfo.enemiesInfo.Length) - 1].EnemyProfile;
        }
    }
}
