using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : SingleTon<BattleManager>
{
    public GameObject CardSelectCanvas;
    public GameObject ResultCanvas;

    public int MonsCount=10;
    public float BattleTimer;
    public PlayerData player;

    public MonDataBase mons;

    public Deck deck;
    public List<CardData> hands;
    public List<CardData> grave;
    public SummonPattern Sp;
    public List<GameObject> monsters;

    private void Start()
    {
        MonsCount = 10;
        deck= PlayerManager.Instance.PlayerDeck;
        //hands= new List<CardData>();
        grave= new List<CardData>();

        player = PlayerManager.Instance.PlayerData1;
        deck.Shuffle();
    }
    private void Update()
    {
        BattleTimer += Time.deltaTime;
        if (BattleTimer > 20 &&Input.GetButtonDown("TimeUp"))
        {
            ShowCardSelectCanvas();
            BattleTimer = 0;
        }
        if (CardSelectCanvas != null)
        {
            if (CardSelectCanvas.activeSelf == true|| ResultCanvas.activeSelf==true)
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
        if (MonsCount <= 0)
        {
            ShowResultCanvas();
        }
        
    }

    public void CardUsing()
    {

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