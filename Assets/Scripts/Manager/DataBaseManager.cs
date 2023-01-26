using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CardData;

public class DataBaseManager : SingleTon<DataBaseManager>
{

    public List<CardData> cardDatas = new List<CardData>();
    public List<MonData> mons = new List<MonData>();

    

    private void Awake()
    {

       
    }
}






