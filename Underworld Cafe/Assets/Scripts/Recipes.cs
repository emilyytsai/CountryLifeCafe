using UnityEngine;
using System.Collections.Generic; //for list
using System.Linq;  //for SequenceEqual

public class Recipes : MonoBehaviour
{
    private MoneyScript moneyScript; //reference to money script

    //optimized code -> i turned the lists into structured lists, so ex: the individual 5 token recipes lists are now in a list
    //also made a function that check the recipe value to increment player money accordingly

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyScript = FindAnyObjectByType<MoneyScript>(); 
    }

    ///////////////////////
    //five token recipes//
    public List<List<string>> five_token_recipes = new List<List<string>>()
    {
        new List<string> { "Lettuce", "Tomato" },
        new List<string> { "Strawberries", "Grapes" }
    };

    //////////////////////
    //ten token recipes//
    public List<List<string>> ten_token_recipes = new List<List<string>>()
    {
        new List<string> { "Lettuce", "Tomato", "Carrots" },
        new List<string> { "Strawberries", "Grapes", "Blueberries" }
    };

    //////////////////////////
    //fifteen token recipes//
    public List<List<string>> fifteen_token_recipes = new List<List<string>>()
    {
        new List<string> { "Lettuce", "Tomato", "Carrots", "Cucumbers" },
        new List<string> { "Strawberries", "Grapes", "Blueberries", "Cucumbers" }
    };
    /////////////////////////

    public void recipe_value(List<string> salad)
    {
        //new simple approach -> increment tokens based on number of ingredients
        if (salad.Count == 2)
        {
            moneyScript.AddFiveTokens();
        }
        else if (salad.Count == 3)
        {
            moneyScript.AddTenTokens();
        }
        else if (salad.Count >= 4)
        {
            moneyScript.AddFifteenTokens();
        }
    } 
}
