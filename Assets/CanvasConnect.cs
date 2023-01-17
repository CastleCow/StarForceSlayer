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
    public Image image;
    public TextMeshProUGUI cardName;

    private void Start()
    {
        BattleManager.Instance.CardSelectCanvas= CardSelectCanvas;
        BattleManager.Instance.ResultCanvas= ResultCanvas;
        BattleManager.Instance.player =player;
        PlayerManager.Instance.PlayerData1 = player;
    }
    private void Update()
    {
        text.text = "Cost" + PlayerManager.Instance.PlayerData1.CardUsingCost+"/6";
        cardSprite = BattleManager.Instance.hands[0].Image;
        image.sprite= cardSprite;
        cardName.text = "" + BattleManager.Instance.hands[0].CardName;
    }

    public void Run()
    {

        GameManager.Instance.UnloadScene("BattleScene");
    }

}
