using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int MaxHp, CurHp, BaseDamage;
    public string PlayerName;

    public enum PlayerClass 
    { 
        Knight,
        Thief,
        Cleric,
        Archer,
        Wizard,

        Size
    };

    public PlayerClass Class;
   

    public int CardUsingCost;


}
