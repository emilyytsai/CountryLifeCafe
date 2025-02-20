using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI moneyText;
    public float initial_and_total_money = 0f;
    public float five_money = 5f;
    public float ten_money = 10f;
    public float fifteen_money = 15f;

    bool customer_served = false;

    public void Start() 
    {
        money_text = GameObject.Find("Money Text").GetComponent<Text>();
        moneyText.text = "$ " + initial_and_total_money.ToString();
        // customer_served = false;
    }

    public void AddFiveTokens() 
    {
        initial_and_total_money = initial_and_total_money + five_money;
        moneyText.text = "$ " + initial_and_total_money.ToString();
        customer_served = true;
    }

    public void AddTenTokens() 
    {
        initial_and_total_money = initial_and_total_money + ten_money;
        moneyText.text = "$ " + initial_and_total_money.ToString();
    }

    public void AddFifteenTokens() 
    {
        initial_and_total_money = initial_and_total_money + fifteen_money;
        moneyText.text = "$ " + initial_and_total_money.ToString();
    }
}