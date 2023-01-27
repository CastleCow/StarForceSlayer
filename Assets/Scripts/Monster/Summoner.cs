using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    public SummonPattern sp;
    bool IsSummon = false;
    public List<GameObject> gameObjects = new List<GameObject>();
    
    private void Update()
    {
        sp = BattleManager.Instance.Sp;
        if (IsSummon==false)
        {
            Summon();
        }
    }
    private void Summon()
    {
        
        BattleManager.Instance.MonsCount = sp.monCount;
        for (int i = 0; i < sp.monCount; i++)
        {
            gameObjects.Add(Instantiate(sp.mons[i].prefab, transform.position + sp.StartPosition[i], Quaternion.EulerRotation(0,135,0)));
          
        }
        BattleManager.Instance.monsters = gameObjects;
        IsSummon = true;
    } 
}
