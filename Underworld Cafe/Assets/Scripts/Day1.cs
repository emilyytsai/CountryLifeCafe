using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;   //  The library System.Collections.Generic is needed for list
using System.Linq;  //for SequenceEqual

public class Day1 : MonoBehaviour
{
    //Day 1 Game Manager Script//

    //script references
    private Recipes recipe; //reference to recipes script
    private CookingSystem cookingSystem; //reference to cooking system script
    private MoneyScript moneyScript; //reference to money script
    private Customer customer; //reference to customer script

    //note** i moved this stuff into a sep customer manager script
    // //customer container
    // ////array of customer game objects (which are prefabs of image/sprite and an animator)
    // public GameObject[] customers;
    // //customer counter
    // private int current_customer = 0;

    //track if order is correct
    public bool orderCorrect = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cookingSystem = FindAnyObjectByType<CookingSystem>();
        moneyScript = FindAnyObjectByType<MoneyScript>();
        recipe = FindAnyObjectByType<Recipes>();
        customer = FindAnyObjectByType<Customer>();
        
        //move thru the array of customers
        //next customer is already being called in customer; dont call again here
        //next_customer();
    }

    //code flow//
    //FirstCustomer()
    //SecondCustomer()
    //ThirdCustomer()
    //next_customer()

    public void FirstCustomer() //orders a 5 token salad
    {
        customer.CustomerServed();

        //if the player presses serve w/o putting anything int he bowl
        if (cookingSystem.current_recipe.Count == 0)
        {
            UIManager.Instance.show_feedback("Um, where is my salad?");
            orderCorrect = false;
            return;
        }

        //convert salad to a hashset -> order of salad no longer matters
        //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1.setequals?view=net-9.0

        HashSet<string> recipe_set = new HashSet<string>(cookingSystem.current_recipe);

        //for handling ten token salads -> use any and setequals
        if (recipe.five_token_recipes.Any(r => new HashSet<string>(r).SetEquals(cookingSystem.current_recipe)))
        {
            recipe.recipe_value(cookingSystem.current_recipe); // Increment player money
            orderCorrect = true;
            UIManager.Instance.show_feedback("Thanks for the salad!");
            orderCorrect = false;
        }
        else if (recipe.ten_token_recipes.Any(r => new HashSet<string>(r).SetEquals(cookingSystem.current_recipe)))
        {
            recipe.recipe_value(cookingSystem.current_recipe);
            orderCorrect = true;
            UIManager.Instance.show_feedback("Wow! Thanks for the great salad!");
            orderCorrect = false;
        }
        else
        {
            Debug.Log("Salad is wrong order");
            orderCorrect = false;
            UIManager.Instance.show_feedback("This isn't my order.");
        }
    }
}
