using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    MoneyUp moneyUp;

    // Start is called before the first frame update
    void Start()
    {
        moneyUp = GetComponent<MoneyUp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ItemBuy()
    {
        int _playerMoney = moneyUp.playerMoney;
        int _itemRate = moneyUp._ItemRate;
        if(_playerMoney >= _itemRate)
        {
            _playerMoney -= _itemRate;

        }

    }
}
