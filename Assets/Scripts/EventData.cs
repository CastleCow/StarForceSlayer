using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventData : MonoBehaviour
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI m_flavortext;
    private string text;



    [SerializeField]
    private Button Accept;
    [SerializeField]
    private Button Reject;

    private void Start()
    {
        image.sprite= sprite;
        text = "Welcome to my rare, If you contract to me, I'll give you some Power";
        m_flavortext.text= text;
        Accept.onClick.AddListener(AcceptEffect);
        Reject.onClick.AddListener(RejectEffect);

    }
    private void OnEnable()
    {
        text = "Welcome to my rare, If you contract to me, I'll give you some Power";
        m_flavortext.text = text;
    }
    public void AcceptEffect()
    {
        text = "Okay Farewell, Little Immortal";
        m_flavortext.text = text;
        PlayerManager.Instance.PlayerData1.BaseDamage += 1;
    }

    public void RejectEffect()
    {
        text = "Get away, Little Immortal";
        m_flavortext.text = text;
        PlayerManager.Instance.PlayerData1.CurHp -= 10;
    }
    
}
