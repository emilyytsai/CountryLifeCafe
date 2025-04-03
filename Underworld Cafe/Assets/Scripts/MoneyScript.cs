using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour
{
    public static MoneyScript Instance { get; private set; } //singleton so money stays persistent

    [SerializeField]
    public TextMeshProUGUI moneyText;

    //money/token values
    public int tokens = 0;
    // public int five_tokens = 5;
    // public int ten_tokens = 10;
    // public int fifteen_tokens = 15;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else //destroy duplicate instance if found
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateMoneyText();
    }

    public void UpdateMoneyText() //made this a function for cleaner code
    {
        moneyText.text = "$ " + tokens.ToString();
    }
    
    public void AddFiveTokens() 
    {
        tokens += 5;
        UpdateMoneyText();
    }

    public void AddTenTokens()
    {
        tokens += 10;
        UpdateMoneyText();
    }

    public void AddFifteenTokens()
    {
        tokens += 15;
        UpdateMoneyText();
    }

    public int get_tokens()
    {
        return tokens;
    }
}