using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private ShowCard[] m_cardButton;
    [SerializeField]
    private Button[] m_Button;
    [SerializeField]
    private GameObject[] m_filter;

    [SerializeField]
    private TextMeshProUGUI m_Wallet;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<m_cardButton.Length;i++)
        {
            m_cardButton[i].thisId = Random.Range(1, DataBaseManager.Instance.cardDatas.Count);
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < m_cardButton.Length; i++)
        {
            m_cardButton[i].thisId = Random.Range(1, DataBaseManager.Instance.cardDatas.Count);
        }
    }
    // Update is called once per frame
    void Update()
    {
        m_Wallet.text = "Wallet: " + PlayerManager.Instance.PlayerInventory.Money;
    }

    public void Reroll()
    {
        for (int i = 0; i < m_cardButton.Length; i++)
        {
            int rand = Random.Range(1, DataBaseManager.Instance.cardDatas.Count);
            Debug.Log(rand);
            m_cardButton[i].thisId = rand;
            m_Button[i].enabled= true;
            m_filter[i].SetActive(false);
            
        }

    }

}
