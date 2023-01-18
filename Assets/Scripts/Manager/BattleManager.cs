using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : SingleTon<BattleManager>
{
    public GameObject CardSelectCanvas;
    public GameObject ResultCanvas;

    public int MonsCount;
    public float BattleTimer;
    public PlayerData player;

    public MonDataBase mons;

    public Deck deck;
    public List<CardData> hands;
    public List<CardData> grave;


    private void Start()
    {
        deck= PlayerManager.Instance.PlayerDeck;
        hands= new List<CardData>();
        grave= new List<CardData>();

        player = PlayerManager.Instance.PlayerData1;
        deck.Shuffle();
    }
    private void Update()
    {
        if (CardSelectCanvas != null)
        {
            if (CardSelectCanvas.activeSelf == true)
            {
                GameManager.Instance.Pause();
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                GameManager.Instance.Resume();
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        if (PlayerManager.Instance.PlayerData1.CurHp < 0)
        {
            
        }
        
    }
    public void ShowResultCanvas()
    {
        ResultCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void ShowCardSelectCanvas()
    {
        CardSelectCanvas.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        
    }
}
/*
 ���ͼ� üũ
 ���� ���� ����� ����Ʈ ��
    ���Ͱ� HP<=0�Ǹ� ���� ī��Ʈ�� --�ϰ� �ش���� ��Ȱ��ȭ 
    ���� ī�� ȹ�� ��ȹ�� 
 �����ð� ������ ī�� ���þ� ��ưȰ��ȭ
    -�� ������ 6�� -�ڽ�Ʈ ������ ī�� ���� -���õ� ī�带 ť��(�ڵ�)�� ����
    -���õ� ī�带 ������ �����ϰ� ����� 
    
ť�ٸ� �÷��̾�� �ο�
 �÷��̾� HP0�ɽ� ���ӿ�����
    -
 


 
 */