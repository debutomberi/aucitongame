using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    //好きな商品かどうかの判断をさせる

    GameObject Favorite; //お気に入りの商品

    // Start is called before the first frame update
    void Start()
    {
        Favorite = GameObject.FindGameObjectWithTag("Art");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アイテムチェック
    void itemCheck()
    {
        
    }
}
