using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUp : MonoBehaviour
{
    int UpMoney; // 上げる金額
    public int playerMoney; // NPCのマネー
    int UpperLimit = 0; // 上げられる表向きの金額上限
    public int OneUpLimit; //一度に挙げられる金額の上限 


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
        if (UpperLimit < 1000 && playerMoney > 0){

            UpperLimit += 100;
            playerMoney -= 100;
            Debug.Log(transform.name + "残り金額" + playerMoney + "円です");

        }
        

    }

}
