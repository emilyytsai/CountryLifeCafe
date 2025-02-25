using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI moneyText;

    //money values
    public float initial_and_total_money = 0f;
    public float five_money = 5f;
    public float ten_money = 10f;
    public float fifteen_money = 15f;

    private bool customer_served = false; //changed to private bool so only this script can modify it for now

    public void Start() 
    {
        UpdateMoneyText();
    }

    private void UpdateMoneyText() //made this a function for cleaner code
    {
        moneyText.text = "$ " + initial_and_total_money.ToString();
    }

    public void CustomerServed()
    {
        customer_served = true;
    }
    public void AddFiveTokens() 
    {
        //initial_and_total_money = initial_and_total_money + five_money;
        if (customer_served) //added if statement so money is added only if customer served bool = true
        {                    //later, this will be a nested if statement when salads & recipes get implemented
            initial_and_total_money += five_money; //ex: if(correct_recipe), then the money will be added
            UpdateMoneyText();
            customer_served = false; //reset bool back to false so money isnt continously added
        }
    }

    //UNCOMMENT FOLLOWING CODE WHEN SALADS & RECIPES ARE IMPLEMENTED

    //public void AddTenTokens() 
    //{
        ////initial_and_total_money = initial_and_total_money + ten_money;
        //if (customer_served)
        //{
            //initial_and_total_money += ten_money;
            //UpdateMoneyText();
            //customer_served = false;
        //}
    //}

    //public void AddFifteenTokens() 
    //{
        ////initial_and_total_money = initial_and_total_money + fifteen_money;
        //if (customer_served)
        //{
            //initial_and_total_money += five_money;
            //UpdateMoneyText();
            //customer_served = false;
        //}
    //}
}