using UnityEngine;
using System.Collections.Generic; //for list 

public class Recipes : MonoBehaviour
{
    //moved the lists dianella made to recipe script; implement the recipe sys later
    private List<string> first_five_token_recipe = new List<string> { "Lettuce", "Tomato" };    // Initialize a new list named first_five_token_recipe which holds the first five token recipe
    private List<string> second_five_token_recipe = new List<string> { "Strawberries", "Grapes" };  // Initialize a new list named second_five_token_recipe which holds the first second token recipe

    private List<string> first_ten_token_recipe = new List<string> { "Lettuce", "Tomato", "Carrots" };  // Initialize a new list named first_ten_token_recipe which holds the first ten token recipe
    private List<string> second_ten_token_recipe = new List<string> { "Strawberries", "Grapes", "Blueberries" };    // Initialize a new list named second_ten_token_recipe which holds the second ten token recipe

    private List<string> first_fifteen_token_recipe = new List<string> { "Lettuce", "Tomato", "Carrots", "Cucumbers" }; // Initialize a new list named first_fifteen_token_recipe which holds the first fifteen token recipe
    private List<string> second_fifteen_token_recipe = new List<string> { "Strawberries", "Grapes", "Blueberries", "Cucumbers" };   // Initialize a new list named second_fifteen_token_recipe which holds the second fifteen token recipe

}
