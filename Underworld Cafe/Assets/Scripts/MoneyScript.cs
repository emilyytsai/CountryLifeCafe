using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour
{
    [SerializeField]
    public float Money = 0f;
    public TextMeshProUGUI moneyText;

    public void Start() 
    {
        moneyText.text = "$ " + Money.ToString();
    }
}