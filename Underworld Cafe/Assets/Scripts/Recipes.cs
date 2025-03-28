using UnityEngine;
using System.Collections.Generic; //for list
using System.Linq;  //for SequenceEqual

public class Recipes : MonoBehaviour
{
    private MoneyScript moneyScript; //reference to money script

    //optimized code -> i turned the lists into structured lists, so ex: the individual 5 token recipes lists are now in a list
    //also made a function that check the recipe value to increment player money accordingly

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

    //check if the recipe is x amt of tokens
    //also resource abt the lambda operator used:
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator

    public void recipe_value(List<string> salad)
    {
        if (five_token_recipes.Any(recipe => recipe.SequenceEqual(salad)))
        {
            moneyScript.AddFiveTokens();
            return;
        }
        if (ten_token_recipes.Any(recipe => recipe.SequenceEqual(salad)))
        {
            moneyScript.AddTenTokens();
            return;
        }
        if (fifteen_token_recipes.Any(recipe => recipe.SequenceEqual(salad)))
        {
            moneyScript.AddFifteenTokens();
            return;
        }
    }
}
