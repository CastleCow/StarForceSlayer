using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnGauge : MonoBehaviour
{
    [SerializeField]
    private Image Gauge;
    private float Timer;
    private float maxTimer=20f;
    // Start is called before the first frame update
    void Start()
    {
        Timer = BattleManager.Instance.BattleTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Timer = BattleManager.Instance.BattleTimer;
        if(Timer < maxTimer )
        Gauge.fillAmount = Timer / maxTimer;
    }
}
