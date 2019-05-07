using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TurnManeger : MonoBehaviour
{
    //客の総数の変数
    int playerCount;

    //売り物の総数の変数
    int totalItemCount;

    //客の総数の変数
    int totalCustomer;

    //一回の買い物が終わったかどうかの変数
    bool sold = false;

    //完売したかの変数
    bool allSoldOut = false;

    [SerializeField]
    GameObject InputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //競りが終わったらscene移動
        if (allSoldOut == true) {
            SceneManager.LoadScene("");
        }
    }

    void Turn() {

        while (sold == false){
            for (int i = playerCount; i >= 0; i++) {

            }
        }
    }
}