using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

//카드를 보여주는 스크립트 
public class ShowCard : MonoBehaviour//,IDraggable
{
    private CardDataBase m_base;
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
    private TextMeshProUGUI effectText;
    [SerializeField]
    private Sprite cardImage;
    public Image image;
    private void Awake()
    {
      
       
    }
    private void Start()
    {
        m_base = GameObject.Find("CardDataBase").GetComponent<CardDataBase>();
        cards[0] = m_base.datas[thisId];
    }
    private void Update()
    {
        cards[0] = m_base.datas[thisId];
        cardId   = cards[0].CardNum;
        cardName = cards[0].CardName;
        cardCost = cards[0].Cost;
        Damage   = cards[0].Damage;
        cardImage = cards[0].Image;
        nameText.text   = "" +  cardName;
        costText.text   = "" +  cardCost;
        effectText.text = " " + Damage;
        image.sprite = cardImage;

    }
        
}
