using UnityEngine;
using System.Collections.Generic;   //  The library System.Collections.Generic is needed for list

public class CookingSystem : MonoBehaviour
{
    public GameObject bowl; // Initialize a variable named bowl with the class GameObject
    private GameObject ingredient;  // Initialize a variable named ingredient which will hold the last clicked ingredient 
    public InputHandler input_handler;   // Initialize input_handler to be a reference to the class InputHandler

    //sprites for how the ingredients look when added to the bowl
    public GameObject tomato_bowl = null;
    public GameObject lettuce_bowl = null;
    public GameObject strawberry_bowl = null;
    public GameObject grape_bowl = null;
    public GameObject cucumber_bowl = null;
    public GameObject blueberries_bowl = null;
    public GameObject carrot_bowl = null;

    public List<string> current_recipe = new List<string>();

    public void AddIngredientToBowl(GameObject ingredient)
    {
        if (ingredient != null && bowl != null) // If ingredient and bowl are assigned and contain references to GameObjects
        {
            string ingredient_name = ingredient.name; //get the name of the ingredient

            // Logic to "add" the ingredient to the bowl
            Debug.Log($"Added {ingredient.name} to the bowl!"); // Output "Added *ingredient name* to the bowl" to the console during gameplay

            trigger_ingredient_sprite(ingredient_name); //add the sprite that looks like the ingredients are actaully in the bowl

            //UNCOMMENT THIS AFTER FARM**
            //destroy the ingredient from the shelf after u add it
            ingredient.SetActive(false);
        }
    }

    void trigger_ingredient_sprite(string ingredient_name)
    {
        //trigger the ingrtedient sprite based off the selected ingredient gameobj
        //using switch statments as substitute for if else if to save me a headache
        switch (ingredient_name)
        {
            case "Tomato":
                enable_tomato();
                break;

            case "Lettuce":
                enable_lettuce();
                break;
            
            case "Strawberry":
                enable_strawberry();
                break;

            case "Grape":
                enable_grape();
                break;
            
            case "Cucumber":
                enable_cucumber();
                break;

            case "Blueberries":
                enable_blueberries();
                break;

            case "Carrot":
                enable_carrot();
                break;

            default:
                break;
        }
    }

    void enable_tomato()
    {
        if (tomato_bowl != null)
        {
            tomato_bowl.SetActive(true); //enable the tomato
            Debug.Log("tomato in bowl");

            //activeInHierarchy = boolean property of a game obj; true if active
            //this is needed bc before it would still check the tomato in current recipe
            if (tomato_bowl.activeInHierarchy && !current_recipe.Contains("Tomato"))
            {
                current_recipe.Add("Tomato");
                Debug.Log(current_recipe[0]); //idk y but when this is at index 1 it creates a duplicate tomato
            }
        }
    }

    void enable_lettuce()
    {
        if (lettuce_bowl != null)
        {
            lettuce_bowl.SetActive(true);
            Debug.Log("lettuce in bowl");

            if (lettuce_bowl.activeInHierarchy && !current_recipe.Contains("Lettuce"))
            {
                current_recipe.Add("Lettuce");
                Debug.Log(current_recipe[0]);
            }
        }
    }

    void enable_strawberry()
    {
        if (strawberry_bowl != null)
        {
            strawberry_bowl.SetActive(true);
            Debug.Log("strawberry in bowl");

            if (strawberry_bowl.activeInHierarchy && !current_recipe.Contains("Strawberry"))
            {
                current_recipe.Add("Strawberry");
                Debug.Log(current_recipe[0]);
            }
        }
    }

    void enable_grape()
    {
        if (grape_bowl != null)
        {
            grape_bowl.SetActive(true);
            Debug.Log("grape in bowl");

            if (grape_bowl.activeInHierarchy && !current_recipe.Contains("Grape"))
            {
                current_recipe.Add("Grape");
                Debug.Log(current_recipe[0]);
            }
        }
    }

    void enable_cucumber()
    {
        if (cucumber_bowl != null)
        {
            cucumber_bowl.SetActive(true);
            Debug.Log("cucumber in bowl");

            if (cucumber_bowl.activeInHierarchy && !current_recipe.Contains("Cucumber"))
            {
                current_recipe.Add("Cucumber");
                Debug.Log(current_recipe[0]);
            }
        }
    }

    void enable_blueberries()
    {
        if (blueberries_bowl != null)
        {
            blueberries_bowl.SetActive(true);
            Debug.Log("blueberries in bowl");

            if (blueberries_bowl.activeInHierarchy && !current_recipe.Contains("Blueberries"))
            {
                current_recipe.Add("Blueberries");
                Debug.Log(current_recipe[0]);
            }
        }
    }

    void enable_carrot()
    {
        if (carrot_bowl != null)
        {
            carrot_bowl.SetActive(true);
            Debug.Log("carrot in bowl");

            if (carrot_bowl.activeInHierarchy && !current_recipe.Contains("Carrot"))
            {
                current_recipe.Add("Carrot");
                Debug.Log(current_recipe[0]);
            }
        }
    }
}