using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IndexData : MonoBehaviour
{
    private CardDataBase m_base;
    public int thisid;
    private int cardNum;//ī�� ��ȣ
    private string cardName;//ī�� �̸�
    private int amount=0;//ī�� ������
    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        text= GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        m_base = GameObject.Find("CardDataBase").GetComponent<CardDataBase>();
    }
    private void Update()
    {
        cardNum = thisid;
        //cardName = m_base.datas[thisid].name;
        //cardName = m_base.datas[thisid].name;
        //text.text = cardNum+" "+cardName+"  "+amount;
    }
}
