using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SakuraManager : MonoBehaviour
{
    public MoneyPlus moneyPlus;
    [SerializeField]
    public Text aaa;

    void Start()
    {
        moneyPlus = GetComponent<MoneyPlus>();
        UpdateLabel();
    }

    private void Update()
    {
        UpdateLabel();
    }

    //クリック時金額を上げる
    public void UpClick()
    {
        int _ItemRate = moneyPlus._ItemRate + 500;
        UpdateLabel();
    }

    //入札時元々の金額に足されるようにする
    public void bidClick()
    {
        moneyPlus._ItemRate = moneyPlus._ItemRate + 500;
        //_ItemRate(合計金額の表示)
        aaa.text = moneyPlus._ItemRate + "円";
    }
    
    public void UpdateLabel()
    {
        aaa.text = moneyPlus._ItemRate + "円";
    }
}