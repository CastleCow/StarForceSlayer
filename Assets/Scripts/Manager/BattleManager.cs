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

    public List<CardData> deck;
    public List<CardData> hands;
    public List<CardData> grave;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerData>();
    }
    private void Update()
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
 몬스터수 체크
 몬스터 전원 사망시 리절트 씬
    몬스터가 HP<=0되면 몬스터 카운트를 --하고 해당몬스터 비활성화 
    랜덤 카드 획득 돈획득 
 일정시간 지난후 카드 선택씬 버튼활성화
    -덱 셔플후 6장 -코스트 내에서 카드 선택 -선택된 카드를 큐바에 저장
    -선택된 카드를 덱에서 제거하고 땡기고 
    
큐바를 플레이어에게 부여
 플레이어 HP0될시 게임오버씬
    -
 


 
 */