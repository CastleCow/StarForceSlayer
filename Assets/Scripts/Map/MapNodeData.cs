using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MapNodeData :MonoBehaviour
{
    
    public enum NodeType
    {
        Start,
        Null,
        NormalBattle,
        EliteBattle,
        Shop,
        Event,
        BossBattle,

        Size
    }
    public NodeType nodeType;

    public bool usedNode;
    public MapMaker map;
    public int NodeNum;
    public Button m_button;
    
    public MapNodeData prevNode;
    public MapNodeData[] nextNode;
    public GameObject filter;

    public MapNodeData() { }
    public MapNodeData(NodeType nodetype,bool usedNode, MapNodeData prevnode, MapNodeData[] nextnode)
    {
        nodeType = nodetype;
        this.usedNode=usedNode;
        this.prevNode=prevnode;
        nextNode=nextnode;
       
    }
    private void Start()
    {
        map = FindObjectOfType<MapMaker>();
    }
    public void NodeClick()
    {
        switch(nodeType)
        {
            case NodeType.Event:
                //GameObject.FindWithTag("Event").SetActive(true);
                GameManager.Instance.EventPop.SetActive(true);
                break;

            case NodeType.Shop:
                //GameObject.FindGameObjectWithTag("Shop").SetActive(true);
                GameManager.Instance.ShopPop.SetActive(true);
                
                break;

            case NodeType.NormalBattle:
                int i=Random.Range(0, 3);
                BattleManager.Instance.Sp = DataBaseManager.Instance.summonPatterns[i];
                GameManager.Instance.LoadScene("BattleScene");
                break;
            case NodeType.EliteBattle:

                BattleManager.Instance.Sp = DataBaseManager.Instance.summonPatterns[3];
                GameManager.Instance.LoadScene("BattleScene");
                break;
            case NodeType.BossBattle:
                BattleManager.Instance.Sp = DataBaseManager.Instance.summonPatterns[4];
                GameManager.Instance.LoadScene("BattleScene");
                break;
        }
        usedNode = true;
    }
    public void NodeUsed()
    {
        if (filter == null || m_button == null)
            return;
        filter.SetActive(true);
        m_button.enabled = false;
        
    }
    public void NumToMap()
    {
        map.clickedNodeNum = NodeNum;
        map.click = true;
    }

}
