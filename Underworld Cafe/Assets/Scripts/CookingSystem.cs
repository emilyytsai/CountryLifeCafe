using UnityEngine;
using System.Collections.Generic;   //  The library System.Collections.Generic is needed for list

public class CookingSystem : MonoBehaviour
{
    public GameObject bowl; // Initialize a variable named bowl with the class GameObject
    private GameObject ingredient;  // Initialize a variable named ingredient which will hold the last clicked ingredient 
    public InputHandler input_handler;   // Initialize input_handler to be a reference to the class InputHandler

    //sprites for how the ingredients look when added to the bowl
    public GameObject tomato_bowl;
    public GameObject lettuce_bowl;

    public List<string> current_recipe = new List<string>();

    public void AddIngredientToBowl(GameObject ingredient)
    {
        if (ingredient != null && bowl != null) // If ingredient and bowl are assigned and contain references to GameObjects
        {
            string ingredient_name = ingredient.name; //get the name of the ingredient

            // Logic to "add" the ingredient to the bowl
            Debug.Log($"Added {ingredient.name} to the bowl!"); // Output "Added *ingredient name* to the bowl" to the console during gameplay

            // Optionally, you can parent the ingredient to the bowl or move it
            //ingredient.transform.parent = bowl.transform;   // Change the parent-child relationship between the ingredient GameObject and the bowl GameObject
            //ingredient.transform.localPosition = new Vector3(0, 100f, 0); // Lower the Y-axis (e.g., -0.5)
            // ingredient.transform.localPosition = Vector3.zero; // Reset the local position of the ingredient GameObject to the origin (0, 0, 0) relative to its parent (the bowl)

            //NOTE* for future reference add the ingredient to a "current recipe" list to check if the recipe is right + add if condition so only the right ingredient is added
            
            trigger_ingredient_sprite(ingredient_name); //add the sprite that looks like the ingredients are actaully in the bowl
        
            //destroy the ingredient from the shelf after u add it
            Destroy(ingredient);
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

            default:
                break;
        }
    }

    void enable_tomato()
    {
        if (tomato_bowl != null)
        {
            tomato_bowl.SetActive(true); //enable the tomato
            current_recipe.Add("Tomato");
            Debug.Log(current_recipe[0]); //idk y but when this is at index 1 it creates a duplicate tomato
            Debug.Log("tomato in bowl");
        }
    }

    void enable_lettuce()
    {
        if (lettuce_bowl != null)
        {
            lettuce_bowl.SetActive(true);
            current_recipe.Add("Lettuce");
            Debug.Log(current_recipe[0]);
            Debug.Log("lettuce in bowl");
        }
    }
}