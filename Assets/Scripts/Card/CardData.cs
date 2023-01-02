using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public int              CardNum;                     //ī�� ��ȣ (������)
    public string           CardName;                    //ī�� �̸� 

    public enum CardAttackMethod
    {
        Raycast,
        Range
    };                                                   //ī�� ���ݹ��: ���� ����ĳ��Ʈ�� ĭ ���� �������� ����
    public CardAttackMethod  attackMethod;
    public int               Damage;                     //ī�� ������ 
    public int?              CardRange;                  //ĭ ���������� ����� ī�� ����
    public int?              Price;                      //ī�� �춧�� ����
    public int               Cost;                       //ī�� ���� �ڽ�Ʈ

    public CardData()
    {

    }
    public CardData(int cardNum, string cardName, CardAttackMethod attackMethod, int damage, int? cardRange, int? price, int cost)
    {
        CardNum = cardNum;
        CardName = cardName;
        this.attackMethod = attackMethod;
        Damage = damage;
        CardRange = cardRange;
        Price = price;
        Cost = cost;
    }
}
