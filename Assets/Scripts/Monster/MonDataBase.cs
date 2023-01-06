using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonDataBase : MonoBehaviour
{
    public List<MonData> mons= new List<MonData>();

    private void Awake()
    {
        mons.Add(new MonData(0,"NULL",0,0,0));
        mons.Add(new MonData(1,"Wolf",40,40,10));
        mons.Add(new MonData(2,"Wolf+",60,60,10));
        mons.Add(new MonData(3,"Scorpion",50,50,10));
        mons.Add(new MonData(4,"ScorpionKing",100,100,10));
        mons.Add(new MonData(5,"Wraith",300,300,10));
    }
}
