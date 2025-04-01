using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUIManager : MonoBehaviour
{
    public EnemySpawn.isBoss bossType = EnemySpawn.isBoss.NONE;
    public Image EnemyHealthBar;
    public Enemy enemy;
    public GameObject miniboss, boss;
    bool isBossDead = false;
    // Start is called before the first frame update
    void OnEnable()
    {
        miniboss.SetActive(false);
        boss.SetActive(false);
        switch (bossType)
        {
            case EnemySpawn.isBoss.MINIBOSS:
                miniboss.SetActive(true);
                break;
            case EnemySpawn.isBoss.BOSS:
                boss.SetActive(true);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
}
