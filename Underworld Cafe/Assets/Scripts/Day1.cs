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
    ////array of customer game objects (which are prefabs of image/sprite and an animator)
    public GameObject[] customers;
    //customer counter
    private int current_customer_index = 0;

    //track if order is correct
    public bool orderCorrect = false;

    //public GameObject customer_prefab;
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
        next_customer();
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

        //now uses sequence equal method to directly compare first recipe (at index 0) of the 5 token recipe lists to the current
        //no longer uses for loop
        if (cookingSystem.current_recipe.SequenceEqual(recipe.five_token_recipes[0]))
        {
            Debug.Log("Salad is correct");
            recipe.recipe_value(cookingSystem.current_recipe); //increment player money
            orderCorrect = true;
            UIManager.Instance.show_feedback("Thanks for the salad!");
        }
        else
        {
            Debug.Log("Salad is wrong order");
            orderCorrect = false;
            UIManager.Instance.show_feedback("This isn't my order.");
        }
    }

    //move thru the array only when this function is called
    public void next_customer()
    {
        if (current_customer_index < customers.Length)
        {
            //customers[current_customer_index].SetActive(true); //spawn the current customer
            //instead of setting active, spawn the new prefab
            current_customer = Instantiate(customers[current_customer_index], new Vector3(-12, 2, 0), Quaternion.identity);
            
            //animator is now dynamically assigned once customer spawns/gets instantiated
            Animator customer_animator = current_customer.GetComponent<Animator>();
            if (customer_animator != null)
            {
                current_customer.GetComponent<Customer>().animator = customer_animator;
            }
            
            current_customer_index++;
        }
        else //once counter is 3
        {
            Debug.Log("day 1 complete");
            //later this is where the day summary will be setactive
        }
    }
}
