using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

//ī�带 �����ִ� ��ũ��Ʈ 
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

    [SerializeField]
    private Button m_but;
    private void Awake()
    {
      
       
    }
    private void Start()
    {
       // m_base = GameObject.Find("CardDataBase").GetComponent<CardDataBase>();
        cards[0] = DataBaseManager.Instance.cardDatas[thisId];
    }
    private void Update()
    {
        cards[0] =DataBaseManager.Instance.cardDatas[thisId];
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
    
    public void ToInventory()
    {
        PlayerManager.Instance.PlayerInventory.Amount[cardId]++;
        PlayerManager.Instance.PlayerDeck.Remove(cards[0]);
    }
    public void BuyCard()
    {
        if(PlayerManager.Instance.PlayerInventory.Money< cards[0].Price) 
        {
            Debug.Log("Not enough Money");
            m_but.enabled = true;
            return;
        }
        PlayerManager.Instance.PlayerInventory.Buy(DataBaseManager.Instance.cardDatas[cardId]);

    }
    
    
}
/*
 public enum ShowSpace{Shop,BattleSelect,Deck,Result,Size}
�� ������ ��ư ���� �����?

 */