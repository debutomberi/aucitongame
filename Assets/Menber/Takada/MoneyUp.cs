using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUp : MonoBehaviour
{
    //CPUが商品の金額をあげるスクリプト

    int UpMoney; // 上乗せする金額
    public int playerMoney; // NPCの所持金
    public static int UpperLimit; // 上乗せできる表向きの合計金額上限
    int OneUpLimit = 10; //一度に上乗せできる金額の上限 
    public int _ItemRate = testItemStatus.testItemRate;

    // Update is called once per frame
    void Update()
    {
        Addition();
    }

    //金額の上乗せ処理
    private void Addition(){

        new WaitForSeconds(3.0f);

        // 手持ち金があり金額上限でなければ上乗せする
        if (UpperLimit <= 1000 && playerMoney >= 100){
      
            UpMoney = 10 * Random.Range(1, OneUpLimit + 1);
            UpperLimit += UpMoney;
            _ItemRate = _ItemRate + UpperLimit;
            Debug.Log(UpperLimit);
            Debug.Log(_ItemRate);
            //Debug.Log(transform.name + "残り金額" + playerMoney + "円です");
     
        }
 
    }

}
