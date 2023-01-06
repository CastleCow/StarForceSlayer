using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonData : ScriptableObject
{
    public int monNum;
    public string monName;
    public int maxHp, curHp, baseDamage;


    public MonData() { }
    public MonData(int monNum, string monName, int maxHp, int curHp, int baseDamage)
    {
        this.monNum = monNum;
        this.monName = monName;
        this.maxHp = maxHp;
        this.curHp = curHp;
        this.baseDamage = baseDamage;
    }
}
