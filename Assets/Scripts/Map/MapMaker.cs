using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    //맥스30칸 첫줄은 무조건 스타트 m_Node[10].NodeType=start;[19]=Boss
    [SerializeField]
    private MapNodeData[] mapNodeList;//start Null ,normal,elite,Shop,Event,Boss

    private int maxNodeSize = 30;
    private int curNode = 0;
    public int clickedNodeNum;
    public bool click;
    public List<MapNodeData> m_Nodes = new List<MapNodeData>();


    // Start is called before the first frame update
    void Start()
    {
        curNode = 0;
        clickedNodeNum = 0;
        click= false;
        maxNodeSize = 30;
        for (int i = 0; i < maxNodeSize; i++)
        {
            m_Nodes.Add(null);
        }

    }

    // Update is called once per frame
    void Update()
    {
        SetAllNode();
        if (click)
        {
            DisableOtherNode();
        }//ShowAllNode();
    }

    void SetAllNode()
    {

        if (curNode < maxNodeSize)
        {
            int ran = Random.Range(1, 6);
            if (curNode == 1) ran = 0;//m_Nodes[curNode] = mapNodeList[1];
            else if (curNode == 28) ran = 6;//m_Nodes[curNode] = mapNodeList[6];
            else if (curNode == 0 || curNode == 2 ||
                curNode == 29 || curNode == 27) ran = 1;// m_Nodes[curNode] = mapNodeList[1]; }

            m_Nodes[curNode] = Instantiate(mapNodeList[ran], transform);
            m_Nodes[curNode].NodeNum = curNode;
            //m_Nodes[curNode].m_button.onClick.AddListener(DisableOtherNode);
            // ShowAllNode(ran);
            curNode++;

        }
    }


    private void DisableOtherNode()
    {
        if (clickedNodeNum == 0) return;
        for (int i = 0; i < clickedNodeNum; i++)
        {
            Debug.Log(m_Nodes[i]);
            m_Nodes[i].NodeUsed();
        }
        if (clickedNodeNum % 3 == 0)
        {
            m_Nodes[clickedNodeNum + 1].NodeUsed();
            m_Nodes[clickedNodeNum + 2].NodeUsed();
        }
        else if(clickedNodeNum % 3 == 1)
        {
            m_Nodes[clickedNodeNum + 1].NodeUsed();

        }
        else
        {

        }
        click = false;
        //clickedNodeNum= 
    }
    private void SetNextNode()
    {
        //m_Nodes[0].nextNode[0]=;
    }

}
