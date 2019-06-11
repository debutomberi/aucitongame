using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour{

    [SerializeField]
    private GameObject statusWindow;
    [SerializeField]
    private GameObject researchWindow;

    [SerializeField]
    private Text customer1;
    [SerializeField]
    private Text customer2;
    [SerializeField]
    private Text customer3;
    [SerializeField]
    private Text customer4;

    [SerializeField]
    private Text Scustomer1;
    [SerializeField]
    private Text Scustomer2;
    [SerializeField]
    private Text Scustomer3;
    [SerializeField]
    private Text Scustomer4;

    [SerializeField]
    private Text researchButton1;
    [SerializeField]
    private Text researchButton2;
    [SerializeField]
    private Text researchButton3;
    [SerializeField]
    private Text researchButton4;


    [SerializeField]
    private Text myMoney;
    [SerializeField]
    private Text product1;
    [SerializeField]
    private Text product2;
    [SerializeField]
    private Text product3;
    [SerializeField]
    private Text product4;


    private bool researchCustomer1 = false;
    private bool researchCustomer2 = false;
    private bool researchCustomer3 = false;
    private bool researchCustomer4 = false;



    
    string customerName1 ;
    string customerName2 ;
    string customerName3 ;
    string customerName4 ;
    string customerLike1 ;
    string customerLike2 ;
    string customerLike3 ;
    string customerLike4 ;
    

    int product = 100;

    void Start(){
        statusWindow.SetActive(false);
        researchWindow.SetActive(false);
        ChangeText();
        
    }

    ////ボタンでscene移動　※移動先のsceneは未制作※

    //public void OnClickShopButton(){
    //    SceneManager.LoadScene("");
    //    Debug.Log("shop画面は出ないはずだよ");
    //}
    
    //public void OnClickResearchButton(){
    //    SceneManager.LoadScene("");
    //    Debug.Log("research画面は出ないはずだよ");
    //}

    //public void OnClickStartAuctionButton(){
    //    SceneManager.LoadScene("");
    //    Debug.Log("オークション画面は出ないはずだよ");
    //}

    //ここまでsceneの移動

    /// <summary>
    ///ボタンを押したらステータス画面を出す
    ///
    ///客の金額(非公開)
    ///客の好み(調査したら公開)
    ///自分の金
    ///商品の種類(商品の金額)
    ///例
    ///銅像(100)・絵画（100）～
    ///Aさん ？？？が好き (boolで管理)
    ///Bさん Fが好き
    ///Cさん Gが好き
    ///Dさん ？？？が好き
    ////// </summary>

    public void OnClickCheckStatusButton(){
        statusWindow.SetActive(true);
    }

    public void OnClickStatusCancelButton(){
        statusWindow.SetActive(false);
    }

    public void OnClickCheckResearchButton()
    {
        researchWindow.SetActive(true);
    }

    public void OnClickResearchCancelButton(){
        researchWindow.SetActive(false);
    }



    public void OnClickResearButton1(){
        if (AitemBox.Instance.money < 500) { return; }
        if (researchCustomer1 == false){
            researchCustomer1 = true;
            
            //所持金を減らす
            AitemBox.Instance.money -= 500;
            Scustomer1.text = UserBox.Instance.UserNameCheck(0) + "は" + UserBox.Instance.UserLikeCheck(0) + "が好きだ";
            researchButton1.text = "調査済み";
            ChangeText();

        }
        
    }

    public void OnClickResearButton2(){
        if (AitemBox.Instance.money < 500) { return; }
        if (researchCustomer2 == false){
            researchCustomer2 = true;

            //所持金を減らす
            AitemBox.Instance.money -= 500;
            Scustomer2.text = UserBox.Instance.UserNameCheck(1) + "は" + UserBox.Instance.UserLikeCheck(1) + "が好きだ";
            researchButton2.text = "調査済み";
            ChangeText();
        }

    }

    public void OnClickResearButton3(){
        if (AitemBox.Instance.money < 500) { return; }
        if (researchCustomer3 == false){
            researchCustomer3 = true;
            
            //所持金を減らす
            AitemBox.Instance.money -= 500;
            Scustomer3.text = UserBox.Instance.UserNameCheck(2) + "は" + UserBox.Instance.UserLikeCheck(2) + "が好きだ";

            researchButton3.text = "調査済み";
            ChangeText();
        }

    }

    public void OnClickResearButton4(){

        if (researchCustomer4 == false){
            researchCustomer4 = true;
            
            //所持金を減らす
            AitemBox.Instance.money -= 500;
            Scustomer4.text = UserBox.Instance.UserNameCheck(3) + "は" + UserBox.Instance.UserLikeCheck(3) + "が好きだ";
            researchButton4.text = "調査済み";
            ChangeText();
        }

    }

    void ChangeText(){
        //Text product1_Text = product1.GetComponent<Text>();
        //Text product2_Text = product2.GetComponent<Text>();
        //Text product3_Text = product3.GetComponent<Text>();
        //Text product4_Text = product4.GetComponent<Text>();

        //Text customer1_Text = customer1.GetComponent<Text>();
        //Text customer2_Text = customer2.GetComponent<Text>();
        //Text customer3_Text = customer3.GetComponent<Text>();
        //Text customer4_Text = customer4.GetComponent<Text>();

        myMoney.text = "所持金："+AitemBox.Instance.money;

        //myMoney_Text = AitemBox.Instance.money;
        product1.text = AitemBox.Instance.AutionAitemName(0);
        product2.text = AitemBox.Instance.AutionAitemName(1);
        product3.text = AitemBox.Instance.AutionAitemName(2);
        product4.text = AitemBox.Instance.AutionAitemName(3);
        //product1.text = customerLike1 + "(" + product + "円)";
        customer1.text = UserBox.Instance.UserNameCheck(0);
        customer2.text = UserBox.Instance.UserNameCheck(1);
        customer3.text = UserBox.Instance.UserNameCheck(2);
        customer4.text = UserBox.Instance.UserNameCheck(3);
    }
    }