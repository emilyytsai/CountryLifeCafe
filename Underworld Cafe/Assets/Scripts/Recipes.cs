using UnityEngine;
using System.Collections.Generic; //for list
using System.Linq;  //for SequenceEqual

public class Recipes : MonoBehaviour
{
    [SerializeField]
    private MoneyScript moneyScript; //reference to money script

    //optimized code -> i turned the lists into structured lists, so ex: the individual 5 token recipes lists are now in a list
    //also made a function that check the recipe value to increment player money accordingly

    ///////////////////////
    //five token recipes//
    public List<List<string>> five_token_recipes = new List<List<string>>()
    {
        new List<string> { "Lettuce", "Tomato" },
        new List<string> { "Strawberry", "Grape" }
    };

    //ten token recipes//
    public List<List<string>> ten_token_recipes = new List<List<string>>()
    {
        new List<string> { "Strawberry", "Grape", "Cucumber" },
        new List<string> { "Lettuce", "Tomato", "Cucumber" },
        new List<string> { "Lettuce", "Tomato", "Carrot" },
        new List<string> { "Strawberry", "Grape", "Blueberries" }
    };

    //////////////////////////
    //fifteen token recipes//
    public List<List<string>> fifteen_token_recipes = new List<List<string>>()
    {
        new List<string> { "Lettuce", "Tomato", "Carrot", "Cucumbers" },
        new List<string> { "Strawberry", "Grape", "Blueberries", "Cucumbers" }
    };
    ///////////////////////

    public void recipe_value(List<string> salad)
    {
        //new simple approach -> increment tokens based on number of ingredients
        if (salad.Count == 2)
        {
            MoneyScript.Instance.AddFiveTokens();
        }
        else if (salad.Count == 3)
        {
            MoneyScript.Instance.AddTenTokens();
        }
        else if (salad.Count >= 4)
        {
            MoneyScript.Instance.AddFifteenTokens();
        }
    } 
}
