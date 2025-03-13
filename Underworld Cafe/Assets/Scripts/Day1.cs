using UnityEngine;

public class Day1 : MonoBehaviour
{
    private Recipes recipe; //reference to recipes script
    private CookingSystem cookingSystem; //reference to cooking system script
    private MoneyScript moneyScript; //reference to money script


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        recipe = FindAnyObjectByType<Recipes>();
        cookingSystem = FindAnyObjectByType<CookingSystem>();
        moneyScript = FindAnyObjectByType<MoneyScript>();
    }

    public void FirstCustomer() //orders a 5 token salad
    {
        if (cookingSystem.current_recipe.Count != recipe.first_five_token_recipe.Count) //checks if the number of elements are equal
        {
            moneyScript.ResetCustomerServed();
        }
        for (int i = 0; i < cookingSystem.current_recipe.Count; i++) //for loop to check if elements are equal; order matters
        {
            if (cookingSystem.current_recipe[i] != recipe.first_ten_token_recipe[i])
            {
                moneyScript.ResetCustomerServed();
            }
        }
        moneyScript.CustomerServed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
