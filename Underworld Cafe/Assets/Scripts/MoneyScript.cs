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
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
        else //destroy duplicate instance if found
        {
            moneyText = GameObject.Find("Money Text")?.GetComponent<TextMeshProUGUI>();
            Destroy(gameObject);
        }
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

    //triggered whenever a scene is loaded
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        //find/update money text reference in new scene
        moneyText = GameObject.Find("Money Text")?.GetComponent<TextMeshProUGUI>();
        
        if (moneyText != null)
        {
            UpdateMoneyText();
        }
    }
}