using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemies : MonoBehaviour
{
    int enemyNum;
    public TextMeshProUGUI enemyNameB;
    public TextMeshProUGUI enemySpeed;
    public TextMeshProUGUI enemyDamage;
    public TextMeshProUGUI enemyPower;
    public buttonTag enemiesScr;
    public enemyClasses guideInfo;
    public Image EnemyProf;
    public GameObject contents;

    public void enemyName()
    {
        //each button has uniqe tag with is attatched to it as an script. each button gets a new teg as its beng cloned and tags will
        //stay there forever since theyre scripts. pressing each button will use its own tag to set picture and information of an enemy.
        if(GlobalValue.LevelPass >= guideInfo.enemiesInfo[enemiesScr.nTag].levelUnlocked)
        {
            enemyNameB.text = guideInfo.enemiesInfo[enemiesScr.nTag].name;
            enemySpeed.text = guideInfo.enemiesInfo[enemiesScr.nTag].speed.ToString();
            enemyDamage.text = guideInfo.enemiesInfo[enemiesScr.nTag].damage.ToString();
            enemyPower.text = guideInfo.enemiesInfo[enemiesScr.nTag].power.ToString();
            EnemyProf.sprite = guideInfo.enemiesInfo[enemiesScr.nTag].EnemyProfile;

            guideBook.lockIconStatic.SetActive(false);
            guideBook.coverStatic.SetActive(false);
        }
        else
        {
            enemyNameB.text = guideInfo.enemiesInfo[(guideInfo.enemiesInfo.Length) - 1].name;
            enemySpeed.text = guideInfo.enemiesInfo[(guideInfo.enemiesInfo.Length) - 1].speed.ToString();
            enemyDamage.text = guideInfo.enemiesInfo[(guideInfo.enemiesInfo.Length) - 1].damage.ToString();
            enemyPower.text = guideInfo.enemiesInfo[(guideInfo.enemiesInfo.Length) - 1].power.ToString();
            EnemyProf.sprite = guideInfo.enemiesInfo[(guideInfo.enemiesInfo.Length) - 1].EnemyProfile;
            
            guideBook.lockIconStatic.SetActive(true);
            guideBook.coverStatic.SetActive(true);

            Debug.Log("ggg");
        }

        SoundManager.PlaySfx(SoundManager.Instance.soundClick);

        /*if(enemyNameB.text == "Locked")
        {
            guideBook.lockIconStatic.SetActive(true);
            guideBook.coverStatic.SetActive(true);
        }
        else
        {
            guideBook.lockIconStatic.SetActive(false);
            guideBook.coverStatic.SetActive(false);
        }*/
    }

    /*public void Update()
    {
        if(enemyNameB.text == "Locked")
        {
            guideBook.lockIconStatic.SetActive(true);
        }
        else
        {
            guideBook.lockIconStatic.SetActive(false);
        }
    }*/
}
