using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasConnect : MonoBehaviour
{
    public GameObject CardSelectCanvas;
    public GameObject ResultCanvas;
    public PlayerData player;

    public TextMeshProUGUI text;

    public Sprite cardSprite;
    public Image[] image;
    public GameObject[] m_objimage;
    public TextMeshProUGUI cardName;

    public float BattleTimer=0;
    public int minute;

    private void Start()
    {
        BattleTimer = 0;
        BattleManager.Instance.CardSelectCanvas= CardSelectCanvas;
        BattleManager.Instance.ResultCanvas= ResultCanvas;
        BattleManager.Instance.player =player;
        //PlayerManager.Instance.PlayerData1 = player;
    }
    private void Update()
    {
        BattleTimer += Time.deltaTime;
        if (BattleTimer > 60)
        {
            minute++;
            BattleTimer = 0;
        }

        text.text = "Cost" + BattleManager.Instance.player.CardUsingCost + "/6";
        /*if (BattleManager.Instance.hands != null) {
            for (int i = 0; i < BattleManager.Instance.hands.Count; i++)
            {
                if (BattleManager.Instance.hands.Count == 1)
                    cardSprite = BattleManager.Instance.hands[i].Image;
                else
                    cardSprite = BattleManager.Instance.hands[i].Image;
                image[i].sprite = cardSprite;
            }
        }*/

        if (BattleManager.Instance.hands.Count == 1)
        {
            cardName.text = "" + BattleManager.Instance.hands[0].CardName;
            cardSprite = BattleManager.Instance.hands[0].Image;
        }
        else
        { 
            cardName.text = "" + BattleManager.Instance.hands[1].CardName;
            cardSprite = BattleManager.Instance.hands[1].Image;
        }
        image[0].sprite = cardSprite;
        CardQueue();
        
    }
    public void CardQueue()
    {
        if (BattleManager.Instance.hands.Count < 3) {
            m_objimage[0].SetActive(false);
            m_objimage[1].SetActive(false);
            m_objimage[2].SetActive(false);
            m_objimage[3].SetActive(false);
            m_objimage[4].SetActive(false);
            return; 
        }

        switch (BattleManager.Instance.hands.Count)
        {
            case 3:
                m_objimage[0].SetActive(true);
                m_objimage[1].SetActive(false);
                m_objimage[2].SetActive(false);
                m_objimage[3].SetActive(false);
                m_objimage[4].SetActive(false);
                break;
            case 4:
                m_objimage[0].SetActive(true);
                m_objimage[1].SetActive(true);
                m_objimage[2].SetActive(false);
                m_objimage[3].SetActive(false);
                m_objimage[4].SetActive(false);
                break;
                
            case 5:
                m_objimage[0].SetActive(true);
                m_objimage[1].SetActive(true);
                m_objimage[2].SetActive(true);
                m_objimage[3].SetActive(false);
                m_objimage[4].SetActive(false);
                break;
            case 6:
                m_objimage[0].SetActive(true);
                m_objimage[1].SetActive(true);
                m_objimage[2].SetActive(true);
                m_objimage[3].SetActive(true);
                m_objimage[4].SetActive(false);
                break;
            case 7:
                m_objimage[0].SetActive(true);
                m_objimage[1].SetActive(true);
                m_objimage[2].SetActive(true);
                m_objimage[3].SetActive(true);
                m_objimage[4].SetActive(true);
                break;
            default:
                m_objimage[0].SetActive(false);
                m_objimage[1].SetActive(false);
                m_objimage[2].SetActive(false);
                m_objimage[3].SetActive(false);
                m_objimage[4].SetActive(false);
                break;

        }
        for(int i=2;i< BattleManager.Instance.hands.Count; i++)
        {
            
                image[i-1].sprite = BattleManager.Instance.hands[i].Image;
        }




    }
    public void Run()
    {
        if (BattleManager.Instance.Sp == DataBaseManager.Instance.summonPatterns[4]) { SceneManager.LoadScene("Clear"); }
        PlayerManager.Instance.PlayerDeck.Add(BattleManager.Instance.grave);
        BattleManager.Instance.hands.RemoveAt(0);
        PlayerManager.Instance.PlayerDeck.Add(BattleManager.Instance.hands);
        BattleManager.Instance.grave.Clear();
        BattleManager.Instance.hands.Clear();
        BattleManager.Instance.hands.Add(DataBaseManager.Instance.cardDatas[0]);
        GameManager.Instance.UnloadScene("BattleScene");
        Cursor.lockState= CursorLockMode.Confined;
    }

}
