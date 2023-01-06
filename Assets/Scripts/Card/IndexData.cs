using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IndexData : MonoBehaviour
{
    private CardDataBase m_base;
    public int thisid=0;
    private int cardNum;//카드 번호
    private string cardName;//카드 이름
    private int amount=0;//카드 소지량
    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        //text= GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        m_base = GameObject.Find("CardDataBase").GetComponent<CardDataBase>();
    }
    private void Update()
    {
        ShowIndex();
    }

    private void ShowIndex()
    {
        
        cardNum = thisid;
        cardName = m_base.datas[thisid].CardName;
        
        //cardName = m_base.datas[thisid].name;
        text.text = cardNum+" "+cardName+"  "+amount;
    }
}
