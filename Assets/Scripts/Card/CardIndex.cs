using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardIndex : MonoBehaviour
{
    private CardDataBase m_base;
    private int indexcount = 0;
    [SerializeField]
    private IndexData m_index;
    // Start is called before the first frame update
    void Start()
    {
        m_base = GameObject.Find("CardDataBase").GetComponent<CardDataBase>();
    }
    private void Update()
    {
        ShowIndexCard();
    }
    private void ShowIndexCard()
    {
        if (indexcount < m_base.datas.Count)
        {   
            Instantiate(m_index, transform);
            m_index.thisid= indexcount+1;
            indexcount++; 
        }
    }
}
