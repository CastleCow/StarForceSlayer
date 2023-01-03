using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CardData : MonoBehaviour
{
    public int              CardNum;                     //ī�� ��ȣ (������)
    public string           CardName;                    //ī�� �̸� 

    public enum CardAttackTarget
    {
        Raycast,
        Range,
        ToMe
    };                                                   //ī�� ���ݹ��: ���� ����ĳ��Ʈ�� ĭ ���� �������� ����
    public CardAttackTarget  attackMethod;
    public int               Damage;                     //ī�� ������ 
    public int?              CardRange;                  //ĭ ���������� ����� ī�� ����
    public int?              Price;                      //ī�� �춧�� ����
    public int               Cost;                       //ī�� ���� �ڽ�Ʈ
    public Sprite            Image;
    public CardData()
    {

    }
    public CardData(int cardNum, string cardName, CardAttackTarget attackMethod, int damage, int? cardRange, int? price, int cost, Sprite image)
    {
        CardNum = cardNum;
        CardName = cardName;
        this.attackMethod = attackMethod;
        Damage = damage;
        CardRange = cardRange;
        Price = price;
        Cost = cost;
        Image = image;
    }
}
