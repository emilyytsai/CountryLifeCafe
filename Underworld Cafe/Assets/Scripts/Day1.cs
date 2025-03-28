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

    //customer container
    ////array of customer game objects
    public GameObject[] customers;
    //customer counter
    private int current_customer_index = 0;

    //track if order is correct
    public bool orderCorrect = false;

    public GameObject customer_prefab;
    private GameObject current_customer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cookingSystem = FindAnyObjectByType<CookingSystem>();
        moneyScript = FindAnyObjectByType<MoneyScript>();
        recipe = FindAnyObjectByType<Recipes>();
        customer = FindAnyObjectByType<Customer>();
        
        //move thru the array of customers
        //next customer is already being called in customer; dont call again here
        //next_customer()
    }

    //code flow//
    //FirstCustomer()
    //SecondCustomer()
    //ThirdCustomer()
    //next_customer()

    public void FirstCustomer() //orders a 5 token salad
    {
        customer.CustomerServed();

        //now uses sequence equal method to directly compare first recipe (at index 0) of the 5 token recipe lists to the current
        //no longer uses for loop
        if (cookingSystem.current_recipe.SequenceEqual(recipe.five_token_recipes[0]))
        {
            Debug.Log("Salad is correct");
            recipe.recipe_value(cookingSystem.current_recipe); //increment player money
            orderCorrect = true;
        }
        else
        {
            Debug.Log("Salad is wrong order");
            orderCorrect = false;
        }
    }

    //move thru the array only when this function is called
    public void next_customer()
    {
        if (current_customer_index < customers.Length)
        {
            //customers[current_customer_index].SetActive(true); //spawn the current customer
            //instead of setting active, spawn the new prefab
            current_customer = Instantiate(customer_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            current_customer_index++;
        }
        else //once counter is 3
        {
            Debug.Log("day 1 complete");
            //later this is where the day summary will be setactive
        }
    }
}
