using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(menuName = "SummonPattern")]

public class SummonPattern : ScriptableObject
{
    public MapNodeData.NodeType type;

    public int monCount;

    public List<MonData> mons;

    public Vector3[] StartPosition;



    
}
