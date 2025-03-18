using UnityEngine;
using System.Collections.Generic;   //  The library System.Collections.Generic is needed for list

public class Day1 : MonoBehaviour
{
    private Recipes recipe; //reference to recipes script
    private CookingSystem cookingSystem; //reference to cooking system script
    private MoneyScript moneyScript; //reference to money script
    private Customer customer; //reference to customer script



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cookingSystem = FindAnyObjectByType<CookingSystem>();
        moneyScript = FindAnyObjectByType<MoneyScript>();
    }

    // public void FirstCustomer() //orders a 5 token salad
    // {
    //     if (cookingSystem.current_recipe.Count != recipe.first_five_token_recipe.Count) //checks if the number of elements are equal
    //     {
    //         moneyScript.ResetCustomerServed();
    //     }
    //     for (int i = 0; i < cookingSystem.current_recipe.Count; i++) //for loop to check if elements are equal; order matters
    //     {
    //         if (cookingSystem.current_recipe[i] != recipe.first_five_token_recipe[i])
    //         {
    //             moneyScript.ResetCustomerServed();
    //         }
    //     }
    //     customer.CustomerServed(); //calls the Customer script's CustomerServed function (which is a function overload of moneyScript's)

    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
