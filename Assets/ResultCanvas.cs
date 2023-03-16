using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultCanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TimerText;
    [SerializeField]
    private Image rewardImage;
    [SerializeField]
    private CanvasConnect cc;
    [SerializeField]
    private TextMeshProUGUI CardNameText;



    private void OnEnable()
    {
        TimerText.text ="Timer"+cc.minute+":"+(int)cc.BattleTimer   ;
        reward();
    }

    void reward()
    {
        int rand = Random.Range(1,DataBaseManager.Instance.cardDatas.Count);
        rewardImage.sprite = DataBaseManager.Instance.cardDatas[rand].Image;
        PlayerManager.Instance.PlayerInventory.Amount[rand]++;
        CardNameText.text = "Get \n" + DataBaseManager.Instance.cardDatas[rand].CardName;
    }
}
