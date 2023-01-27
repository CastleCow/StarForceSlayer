using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingleTon<GameManager>
{
    [SerializeField]
    public GameObject EventPop;
    [SerializeField]
    public GameObject ShopPop;

    public GameObject mapscene;

    private void Update()
    {
      
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene,LoadSceneMode.Additive);
        //SceneManager.LoadSceneAsync(scene,LoadSceneMode.Additive);
        mapscene.SetActive(false);

        
    }
    public void UnloadScene(string scene)
    {
        for(int i = 0;i< BattleManager.Instance.monsters.Count;i++)
            Destroy(BattleManager.Instance.monsters[i]);
        BattleManager.Instance.MonsCount++;
        SceneManager.UnloadSceneAsync(scene);
        mapscene.SetActive(true);
       
    }

}
