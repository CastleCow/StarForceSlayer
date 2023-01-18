using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardIndex : MonoBehaviour
{
    
    
    private int indexcount = 0;
    [SerializeField]
    private IndexData m_index;
    // Start is called before the first frame update
    void Start()
    {
       indexcount= 0;
    }
    private void Update()
    {
        ShowIndexCard();
    }
    private void ShowIndexCard()
    {
        if (indexcount < DataBaseManager.Instance.cardDatas.Count-1)
        {
            Debug.Log("인덱스카운트:"+indexcount);
            Instantiate(m_index, transform);
            m_index.thisid= indexcount+1;
            indexcount++; 
        }
    }
}
