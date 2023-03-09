using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ī�� �����͸� ����
[System.Serializable]
[CreateAssetMenu(menuName ="Card")]
public class CardData : ScriptableObject//MonoBehaviour
{
    public int              CardNum;                     //ī�� ��ȣ (������)
    public string           CardName;                    //ī�� �̸� 

    public enum CardAttackTarget
    {
        Raycast,
        Range,
        ToMe
    };                                                   //ī�� ���ݹ��: ���� ����ĳ��Ʈ�� ĭ ���� �������� ����
    public CardAttackTarget              attackMethod;
    public int                           Damage;                     //ī�� ������ 
    public int                           AttackAngle;
    public int                           AttackRange;                 //ĭ ���������� ����� ī�� ����
    public int                           Price;                      //ī�� �춧�� ����
    public int                           Cost;                       //ī�� ���� �ڽ�Ʈ
    public Sprite                        Image;
    public UseCardSkill                  thisSkill;
    


}
