using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnemyManager : MonoBehaviour, IListener
{
    public static LevelEnemyManager Instance;
    public GameObject FX_Smoke, FX_Blow, GraveHit;
    public SimpleProjectile bullet;
    public Transform BossSpawnPoint;
    public Transform[] spawnPositions;
    public Transform[] underground_spawn_positions;
    public EnemyWave[] EnemyWaves;
    public float enemyScale = 1f;
    public static float _enemyScale;
    public static float _bossScale;
    public static bool isItBoss = false;
    public static bool isItEnemy = false;
    public static float _customBossSpeed;
    [HideInInspector] public int enemyPos;
    [DeviceDependent]
    public DeviceDependentReference bossManeger;
    int currentWave = 0;
    public List<GameObject> listEnemySpawned = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    [HideInInspector]public int totalEnemy, currentSpawn;
    public LevelWave.LevelType levelType;
    // Start is called before the first frame update
    void Start()
    {
        if (GameLevelSetup.Instance)
        {
        levelType = GameLevelSetup.Instance.type();
            if (levelType == LevelWave.LevelType.Endless) {
                this.enabled = false;
                return;
            }
            EnemyWaves = GameLevelSetup.Instance.GetLevelWave();
        }

        //calculate number of enemies
        totalEnemy = 0;
        for (int i = 0; i < EnemyWaves.Length; i++)
        {
            for (int j = 0; j < EnemyWaves[i].enemySpawns.Length; j++)
            {
                var enemySpawn = EnemyWaves[i].enemySpawns[j];
                for (int k = 0; k < enemySpawn.numberEnemy; k++)
                {
                    totalEnemy++;
                }
            }
        }

        currentSpawn = 0;
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemyCo()
    {
        for (int i = 0; i < EnemyWaves.Length; i++)
        {
            yield return new WaitForSeconds(EnemyWaves[i].wait);
            for (int j = 0; j < EnemyWaves[i].enemySpawns.Length; j++)
            {
                var enemySpawn = EnemyWaves[i].enemySpawns[j];
                yield return new WaitForSeconds(enemySpawn.wait);
                for (int k = 0; k < enemySpawn.numberEnemy; k++)
                {
                    Vector2 spawnPos = Vector2.zero;
                    if (enemySpawn.boosType == EnemySpawn.isBoss.NONE)
                        {spawnPos = (Vector2)spawnPositions[enemyPos = Random.Range(0, spawnPositions.Length)].position;
                        //SmartEnemyGrounded.sp.sortingOrder = 2;
                        }
                    else
                        {spawnPos = (Vector2)BossSpawnPoint.position;}
                    GameObject _temp = Instantiate(enemySpawn.enemy,spawnPos,Quaternion.identity) as GameObject;
                    //moved the 2 below lines to the boss manager
                    //_enemyScale = enemyScale;
                    //_temp.transform.localScale = new Vector2(_enemyScale * Enemy._enemyScaleSelf, _enemyScale * Enemy._enemyScaleSelf);
                    var isEnemy = (Enemy)_temp.GetComponent(typeof(Enemy));
                    if (isEnemy != null)
                    {
                        isEnemy.disableFX = FX_Smoke;
                        if (enemySpawn.customHealth > 0)
                            isEnemy.health = enemySpawn.customHealth;
                        if (enemySpawn.customSpeed > 0)
                            _customBossSpeed = enemySpawn.customSpeed;
                        if (enemySpawn.customAttackDmg > 0)
                        {
                            var rangeAttack = _temp.GetComponent<EnemyRangeAttack>();
                            if (rangeAttack)
                            {
                                rangeAttack.damage = enemySpawn.customAttackDmg;
                            }

                            var meleeAttack = _temp.GetComponent<EnemyMeleeAttack>();
                            if (meleeAttack)
                                meleeAttack.dealDamage = enemySpawn.customAttackDmg;
                            var throwAttack = _temp.GetComponent<EnemyThrowAttack>();
                            if (throwAttack)
                            {
                                throwAttack.damage = enemySpawn.customAttackDmg;
                            }
                        }

                        var rangeAttack1 = _temp.GetComponent<EnemyRangeAttack>();
                        if (rangeAttack1)
                            rangeAttack1.bullet = bullet;
                        var meleeAttack1 = _temp.GetComponent<EnemyMeleeAttack>();
                        var throwAttack1 = _temp.GetComponent<EnemyThrowAttack>();
                        if (throwAttack1)
                        {
                            throwAttack1.FX_Blow = FX_Blow;
                            throwAttack1.FX_Smoke = FX_Smoke;
                        }

                        if (enemySpawn.boosType != EnemySpawn.isBoss.NONE)
                        {
                            isItBoss = true;
                            Debug.Log("it is a boss");
                            BossUIManager bsmng = bossManeger.type<BossUIManager>();
                            bsmng.enemy = _temp.GetComponent<Enemy>();
                                if (enemySpawn.BossScale > 1) {
                                    _bossScale = enemySpawn.BossScale;
                                    Vector2 scale = new Vector2(enemySpawn.BossScale * _enemyScale, enemySpawn.BossScale * _enemyScale);
                                bsmng.enemy.gameObject.transform.localScale =
                                 bsmng.enemy.gameObject.transform.localScale * scale;
                                }
                            bsmng.bossType = enemySpawn.boosType;
                            bsmng.enemy.gameObject.TryGetComponent<GiveExpWhenDie>(out GiveExpWhenDie component);
                            if (component) {
                                component.expMin = enemySpawn.BossMinExp;
                                component.expMax = enemySpawn.BossMaxExp;
                            }
                            bsmng.gameObject.SetActive(true);
                            bsmng.enemy.is_boss = true;
                            bsmng.enemy.boss_ui = bsmng;
                            AudioClip bossMusic = bsmng.enemy.BossMusic != null
                                ? bsmng.enemy.BossMusic
                                : SoundManager.Instance.BossMusicClip;
                            SoundManager.PlayMusic(SoundManager.Instance.BossMusicClip, 0.5f);
                        }

                        if (enemySpawn.boosType == EnemySpawn.isBoss.NONE)
                        {
                            isItEnemy = true;
                            _enemyScale = enemyScale;
                            _temp.transform.localScale = new Vector2(_enemyScale * Enemy._enemyScaleSelf, _enemyScale * Enemy._enemyScaleSelf);
                        }
                    }

                    _temp.SetActive(false);
                    _temp.transform.parent = transform;

                    yield return new WaitForSeconds(0.1f);
                    _temp.SetActive(true);

                    listEnemySpawned.Add(_temp);

                    currentSpawn++;
                    MenuManager.Instance.UpdateEnemyWavePercent(currentSpawn, totalEnemy);

                    yield return new WaitForSeconds(enemySpawn.rate);
                    SmartEnemyGrounded.sp.sortingOrder = enemyPos;
                }
            }

            //check all enemy killed
            while (isEnemyAlive())
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.Victory();
    }

    bool isEnemyAlive()
    {
        for (int i = 0; i < listEnemySpawned.Count; i++)
        {
            if (listEnemySpawned[i].gameObject != null && listEnemySpawned[i].activeInHierarchy)
                return true;
        }

        return false;
    }

    public void IGameOver()
    {
        //throw new System.NotImplementedException();
    }

    public void IOnRespawn()
    {
        //throw new System.NotImplementedException();
    }

    public void IOnStopMovingOff()
    {
        //throw new System.NotImplementedException();
    }

    public void IOnStopMovingOn()
    {
        //throw new System.NotImplementedException();
    }

    public void IPause()
    {
        //throw new System.NotImplementedException();
    }

    public void IPlay()
    {
        StartCoroutine(SpawnEnemyCo());
        //throw new System.NotImplementedException();
    }

    public void ISuccess()
    {
        StopAllCoroutines();
        //throw new System.NotImplementedException();
    }

    public void IUnPause()
    {
        //throw new System.NotImplementedException();
    }
    public bool IEnabled() {
        return this.enabled;
    }
}

[System.Serializable]
public class EnemyWave
{
    public float wait = 3;
    public EnemySpawn[] enemySpawns;
}
