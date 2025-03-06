using UnityEngine;
using System.Collections.Generic;   //  The library System.Collections.Generic is needed for list

public class CookingSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<string> first_five_token_recipe = new List<string> { "Lettuce", "Tomato" };    // Initialize a new list named first_five_token_recipe which holds the first five token recipe
        List<string> second_five_token_recipe = new List<string> { "Strawberries", "Grapes" };  // Initialize a new list named second_five_token_recipe which holds the first second token recipe

        List<string> first_ten_token_recipe = new List<string> { "Lettuce", "Tomato", "Carrots" };  // Initialize a new list named first_ten_token_recipe which holds the first ten token recipe
        List<string> second_ten_token_recipe = new List<string> { "Strawberries", "Grapes", "Blueberries" };    // Initialize a new list named second_ten_token_recipe which holds the second ten token recipe

        List<string> first_fifteen_token_recipe = new List<string> { "Lettuce", "Tomato", "Carrots", "Cucumbers" }; // Initialize a new list named first_fifteen_token_recipe which holds the first fifteen token recipe
        List<string> second_fifteen_token_recipe = new List<string> { "Strawberries", "Grapes", "Blueberries", "Cucumbers" };   // Initialize a new list named second_fifteen_token_recipe which holds the second fifteen token recipe
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
