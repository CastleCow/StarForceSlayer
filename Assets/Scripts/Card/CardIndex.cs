using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardIndex : MonoBehaviour
{
    
    
    private int indexcount = new int();
    [SerializeField]
    private IndexData m_index;
    // Start is called before the first frame update
    void Start()
    {
       indexcount= 0;
        for(int i=1;i< DataBaseManager.Instance.cardDatas.Count;i++)
        {
            m_index.thisid = i ;
            Instantiate(m_index, transform);
        }
    }
    private void Update()
    {
       // ShowIndexCard();
    }
    private void ShowIndexCard()
    {
        if (indexcount < DataBaseManager.Instance.cardDatas.Count)
        {
            Debug.Log("인덱스카운트:"+indexcount);
            Instantiate(m_index, transform);
            m_index.thisid= indexcount+1;
            indexcount++; 
        }
    }

    public void ToDeck()
    {

    }
}
