using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasConnect : MonoBehaviour
{
    public GameObject CardSelectCanvas;
    public GameObject ResultCanvas;
    public PlayerData player;

    public TextMeshProUGUI text;

    public Sprite cardSprite;
    public Image[] image;
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
    }

    public void Run()
    {
        PlayerManager.Instance.PlayerDeck.Add(BattleManager.Instance.grave);
        PlayerManager.Instance.PlayerDeck.Add(BattleManager.Instance.hands);
        BattleManager.Instance.grave.Clear();
        BattleManager.Instance.hands.Clear();
        GameManager.Instance.UnloadScene("BattleScene");
        Cursor.lockState= CursorLockMode.Confined;
    }

}
