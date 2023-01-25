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

    private void Start()
    {
        BattleManager.Instance.CardSelectCanvas= CardSelectCanvas;
        BattleManager.Instance.ResultCanvas= ResultCanvas;
        BattleManager.Instance.player =player;
        //PlayerManager.Instance.PlayerData1 = player;
    }
    private void Update()
    {
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

        GameManager.Instance.UnloadScene("BattleScene");
        Cursor.lockState= CursorLockMode.Confined;
    }

}
