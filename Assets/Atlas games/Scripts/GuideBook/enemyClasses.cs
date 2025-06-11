using System;
using UnityEngine;

[CreateAssetMenu(fileName = "enemyClasses", menuName = "Scriptable Objects/enemyClasses")]
public class enemyClasses : ScriptableObject
{
    public enum speed
    {
        Slow,
        Normal,
        Fast
    }
    public enum power
    {
        Weak,
        Strong,
        VeryStrong
    }

    [Serializable]
    public class info
    {
        public string name;
        public speed speed;
        public int damage;
        public power power;
        public Sprite EnemyProfile;
    }

    public info[] enemiesInfo;
}
