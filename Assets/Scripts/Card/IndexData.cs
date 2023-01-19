using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IndexData : MonoBehaviour
{
    
    public int thisid=0;
    private int cardNum;//카드 번호
    private string cardName;//카드 이름
    private int amount=0;//카드 소지량
    [SerializeField]
    private TextMeshProUGUI text;

    
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

    }
}
