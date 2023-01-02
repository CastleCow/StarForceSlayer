using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShowCard : MonoBehaviour
{
    public CardDataBase m_base;
    public List<CardData> cards=new List<CardData>();
    public int thisId=0;

    public int cardId;
    private string cardName;
    private int cardCost;
    private int Damage;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI costText;
    [SerializeField]
    private TextMeshProUGUI EffectText;
    [SerializeField]
    private Image cardImage;

    private void Start()
    {
        cards[0] = m_base.datas[thisId];
    }
    private void Update()
    {
        cardId   = cards[0].CardNum;
        cardName = cards[0].CardName;
        cardCost = cards[0].Cost;
        Damage   = cards[0].Damage;

        nameText.text   = "" +  cardName;
        costText.text   = "" +  cardCost;
        EffectText.text = " " + Damage;

    }

}
