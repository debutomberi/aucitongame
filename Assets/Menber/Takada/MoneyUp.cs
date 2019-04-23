using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUp : MonoBehaviour
{
    public int UpMoney; // 上げる金額
    int playerMoney; // NPCのマネー
    public int UpperLimit = 1000; // 上げる金額上限


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Addition();
    }

    //金額の加算処理
    private void Addition(){

        // 金額上限でなければ加算
        if (UpMoney <= UpperLimit){

            UpMoney += 100;

        }
        

    }

}
