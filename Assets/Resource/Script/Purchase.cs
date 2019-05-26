using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    
    public Aitem setAitem;
    
    public void Buy()
    {
        if(setAitem == null) { return; }
        if (AitemBox.Instance.nextAitem >= 4) {
            Debug.Log("アイテムの所持数がMAXです。");
            return;
            
        }
        if (AitemBox.Instance.money - setAitem.purchasePrice < 0) {
            Debug.Log("金額が不足しています");
            return;
        }
        AitemBox.Instance.money -= setAitem.purchasePrice;
        AitemBox.Instance.Buy(setAitem);
        Debug.Log(setAitem.aitemName + "を購入しました");
        
    }

}
