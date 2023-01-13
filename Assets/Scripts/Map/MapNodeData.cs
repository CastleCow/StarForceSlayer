using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    public int? MonsCount;
    public MapNodeData prevNode;
    public MapNodeData[] nextNode;

    public MapNodeData() { }
    public MapNodeData(NodeType nodetype,bool usedNode, MapNodeData prevnode, MapNodeData[] nextnode)
    {
        nodeType = nodetype;
        this.usedNode=usedNode;
        this.prevNode=prevnode;
        nextNode=nextnode;
        if(nodeType==NodeType.NormalBattle|| nodeType == NodeType.EliteBattle ) { MonsCount = Random.Range(1, 3); }

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
                GameManager.Instance.LoadScene("BattleScene");
                break;
            case NodeType.EliteBattle:
                GameManager.Instance.LoadScene("BattleScene");
                break;
            case NodeType.BossBattle:
                GameManager.Instance.LoadScene("BattleScene");
                break;
        }
        usedNode = true;
     
    }                                            

}
