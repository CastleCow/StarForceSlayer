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

    private List<MapNodeData> m_Nodes = new List<MapNodeData>();

    private void Awake()
    {
        //m_Nodes = GetComponents<List<MapNodeData>>;
    }

    // Start is called before the first frame update
    void Start()
    {
        curNode = 0;
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
        //ShowAllNode();
    }

    void SetAllNode()
    {

        if (curNode < maxNodeSize)
        {
            int start = curNode % 10;


            int ran = Random.Range(1, 6);
            m_Nodes[curNode] = mapNodeList[ran];
            if (curNode == 10) ran = 0;//m_Nodes[curNode] = mapNodeList[1];
            else if (curNode == 19) ran = 6;//m_Nodes[curNode] = mapNodeList[6];
            else if (start == 0 || start == 9) ran = 1;// m_Nodes[curNode] = mapNodeList[1]; }

            ShowAllNode(ran);
            curNode++;

        }
    }
    private void ShowAllNode(int ran)
    {
        
        Instantiate(mapNodeList[ran], transform);
    }
    private void ShowAllNode()
    {
        for(int i=0;i<m_Nodes.Count;i++)
        {
            Instantiate(mapNodeList[(int)(m_Nodes[i].nodeType)], transform);
        }
    }
    

    private void SetNextNode()
    {
        // m_Nodes[0].nextNode[0]=;
    }

}
