﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPlus : MonoBehaviour
{
    //CPUが商品の金額をあげるスクリプト

    public List<GameObject> CPUs = new List<GameObject>(); //CPUを入れるList
    int UpMoney; // 上乗せする金額
    int UppedMoney; //どれだけ上がったか
    public static int UpperLimit = 1000; // 上乗せできる表向きの合計金額上限
    public int OneUpLimit; //一度に上乗せできる金額の上限 

    [SerializeField]
    private float Intaval;
    private float tmpTime = 0;
    int Count;

    public int _ItemRate = testItemStatus.testItemRate;

    // Update is called once per frame
    void Update()
    {
            //インターバル毎に行う処理
            tmpTime += Time.deltaTime;
            if (tmpTime >= Intaval)
            {
                Addition();
                tmpTime = 0;

            }

    }


    //金額の上乗せ処理
    private void Addition()
    {
        // 金額上限でなければ上乗せする

            if (UppedMoney <= UpperLimit)
            {

                UpMoney = 10 * Random.Range(1, OneUpLimit + 1);
                UppedMoney += UpMoney;
                _ItemRate = _ItemRate + UppedMoney;
                Debug.Log(UppedMoney);
                Debug.Log(_ItemRate);
                Debug.Log(CPUs[Count].name + "が掛け金を上乗せしました");
                Count++;
               
           
                if(Count == CPUs.Count)
                {
                    Count = 0;
                }
             
            }


    }
}