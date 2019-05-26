using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purchase : MonoBehaviour
{
    
    public Aitem setAitem;

    [SerializeField]
    Image aitemimage;
    [SerializeField]
    Text paramText;
    [SerializeField]
    Text nameText;

    private void Start()
    {
        SetUI();
    }

    void SetUI()
    {
        aitemimage.sprite = setAitem.aitemImage;
        paramText.text = setAitem.aitemType+"/＄"+setAitem.startPrice+"スタート";
        nameText.text = setAitem.aitemName + "/＄" + setAitem.purchasePrice;
    }

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
