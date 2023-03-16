using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndexData : MonoBehaviour
{
    
    public int thisid=new int();
    private int cardNum;//ī�� ��ȣ
    private string cardName;//ī�� �̸�
    private int amount=0;//ī�� ������
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Button m_but;

    private void Start()
    {
        m_but.onClick.AddListener(ToDeck);
    }
    private void Update()
    {
        ShowIndex();
    }

    private void ShowIndex()
    {
        
        cardNum = thisid;
        cardName = DataBaseManager.Instance.cardDatas[thisid].CardName;
        amount = PlayerManager.Instance.PlayerInventory.Amount[thisid];
        
        text.text = cardNum+" "+cardName+"  "+amount;
    }

    public void ToDeck()
    {
        PlayerManager.Instance.PlayerDeck.Add(DataBaseManager.Instance.cardDatas[thisid]);
    }
}
