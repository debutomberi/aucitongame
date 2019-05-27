﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SucccesfulBid : MonoBehaviour
{
    //落札時の処理

    MoneyPlus _moneyPlus;　
    int cpuMoney;           //CPUの所持金
    int _itemRate;          //落札時のアイテムの金額
    int sales;              //売上

    // Start is called before the first frame update
    void Start()
    {
        _moneyPlus = GetComponent<MoneyPlus>();
        _itemRate = _moneyPlus._ItemRate;
        cpuMoney = _moneyPlus._cpuMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //落札成功
    public void Succes()
    {
        cpuMoney -= _itemRate;
        sales += _itemRate;
    }
}
