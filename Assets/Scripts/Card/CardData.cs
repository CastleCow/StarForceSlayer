using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카드 데이터만 저장
[System.Serializable]
[CreateAssetMenu(menuName ="Card")]
public class CardData : ScriptableObject//MonoBehaviour
{
    public int              CardNum;                     //카드 번호 (도감용)
    public string           CardName;                    //카드 이름 

    public enum CardAttackTarget
    {
        Raycast,
        Range,
        ToMe
    };                                                   //카드 공격방식: 직선 레이캐스트와 칸 범위 공격으로 나뉨
    public CardAttackTarget              attackMethod;
    public int                           Damage;                     //카드 데미지 
    public int                           AttackAngle;
    public int                           AttackRange;                 //칸 범위공격일 경우의 카드 범위
    public int                           Price;                      //카드 살때의 가격
    public int                           Cost;                       //카드 사용시 코스트
    public Sprite                        Image;
    public UseCardSkill                  thisSkill;
    public CardData()
    {

    }
    public CardData(int cardNum, string cardName, CardAttackTarget attackMethod, int damage, int price, int cost, Sprite image)
    {
        CardNum = cardNum;
        CardName = cardName;
        this.attackMethod = attackMethod;
        Damage = damage;
       
        Price = price;
        Cost = cost;
        Image = image;
    }


}
