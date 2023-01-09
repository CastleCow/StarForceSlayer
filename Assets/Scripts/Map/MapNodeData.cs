using System.Collections;
using System.Collections.Generic;
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

    public MapNodeData prevNode;
    public MapNodeData[] nextNode;

    public MapNodeData() { }
    public MapNodeData(NodeType nodetype,bool usedNode, MapNodeData prevnode, MapNodeData[] nextnode)
    {
        nodeType = nodetype;
        this.usedNode=usedNode;
        this.prevNode=prevnode;
        nextNode=nextnode;

    }
                                                  

}
