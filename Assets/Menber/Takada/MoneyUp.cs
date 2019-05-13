using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUp : MonoBehaviour
{
    //CPUが商品の金額をあげるスクリプト

    int UpMoney; // 上げる金額
    public int playerMoney; // NPCのマネー
    public static int UpperLimit; // 上げられる表向きの金額上限
    int OneUpLimit = 10; //一度に挙げられる金額の上限 


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

        // 手持ち金があり金額上限でなければ加算
        if (UpperLimit < 1000 && playerMoney > 100){

            UpMoney = 10 * Random.Range(1, OneUpLimit + 1);
            UpperLimit += UpMoney;
            playerMoney -= UpMoney;
            Debug.Log(transform.name + "残り金額" + playerMoney + "円です");
            //Debug.Log(UpperLimit);

        }
        

    }

}
