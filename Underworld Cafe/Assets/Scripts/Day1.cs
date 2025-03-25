using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;   //  The library System.Collections.Generic is needed for list

public class Day1 : MonoBehaviour
{
    private Recipes recipe; //reference to recipes script
    private CookingSystem cookingSystem; //reference to cooking system script
    private MoneyScript moneyScript; //reference to money script
    private Customer customer; //reference to customer script

    public bool orderCorrect = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cookingSystem = FindAnyObjectByType<CookingSystem>();
        moneyScript = FindAnyObjectByType<MoneyScript>();
        recipe = FindAnyObjectByType<Recipes>();
        customer = FindAnyObjectByType<Customer>();
    }

    public void FirstCustomer() //orders a 5 token salad
    {
        customer.CustomerServed(); //calls the Customer script's CustomerServed function (which is a function overload of moneyScript's)
        if (cookingSystem.current_recipe.Count != recipe.first_five_token_recipe.Count) //checks if the number of elements are equal
        {
            Debug.Log("Salad is insufficient");
            orderCorrect = false;
        }
        for (int i = 0; i < cookingSystem.current_recipe.Count; i++) //for loop to check if elements are equal; order matters
        {
            if (cookingSystem.current_recipe[i] != recipe.first_five_token_recipe[i])
            {
                Debug.Log("Salad is wrong order");
                orderCorrect = false;
            }
        }
        if (orderCorrect) {
            Debug.Log("Salad is correct");
            moneyScript.AddFiveTokens();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
