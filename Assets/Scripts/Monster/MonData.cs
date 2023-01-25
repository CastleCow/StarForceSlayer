using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Monster")]
public class MonData : ScriptableObject
{
    public int monNum;
    public string monName;
    public int maxHp, curHp, baseDamage;

    public enum MonsterType
    {
        None,
        Normal,
        Elite,
        Boss,

    }
    public MonsterType type;

    public GameObject prefab;

    public MonData() { }
    public MonData(int monNum, string monName, int maxHp,MonsterType type,  int baseDamage)
    {
        this.monNum = monNum;
        this.monName = monName;
        this.maxHp = maxHp;
        this.curHp = maxHp;
        this.type = type;
        this.baseDamage = baseDamage;
    }


}
