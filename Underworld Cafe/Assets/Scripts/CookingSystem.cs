using UnityEngine;
using System.Collections.Generic;   //  The library System.Collections.Generic is needed for list

public class CookingSystem : MonoBehaviour
{
    public GameObject bowl; // Initialize a variable named bowl with the class GameObject
    private GameObject ingredient;  // Initialize a variable named ingredient which will hold the last clicked ingredient 
    public InputHandler input_handler;   // Initialize input_handler to be a reference to the class InputHandler
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        private List<string> first_five_token_recipe = new List<string> { "Lettuce", "Tomato" };    // Initialize a new list named first_five_token_recipe which holds the first five token recipe
        private List<string> second_five_token_recipe = new List<string> { "Strawberries", "Grapes" };  // Initialize a new list named second_five_token_recipe which holds the first second token recipe

        private List<string> first_ten_token_recipe = new List<string> { "Lettuce", "Tomato", "Carrots" };  // Initialize a new list named first_ten_token_recipe which holds the first ten token recipe
        private List<string> second_ten_token_recipe = new List<string> { "Strawberries", "Grapes", "Blueberries" };    // Initialize a new list named second_ten_token_recipe which holds the second ten token recipe

        private List<string> first_fifteen_token_recipe = new List<string> { "Lettuce", "Tomato", "Carrots", "Cucumbers" }; // Initialize a new list named first_fifteen_token_recipe which holds the first fifteen token recipe
        private List<string> second_fifteen_token_recipe = new List<string> { "Strawberries", "Grapes", "Blueberries", "Cucumbers" };   // Initialize a new list named second_fifteen_token_recipe which holds the second fifteen token recipe
    }

    // Update is called once per frame
   void Update()
    {
        InputHandler last_selected_ingredient = input_handler.last_selected; // Initialize a new variable named last_selected_ingredient equal to the last selected ingredient

        // Check for mouse clicks
        // if (Input.GetMouseButtonDown(0))    // If the left mouse button was clicked during the current frame
        // {
        //     Debug.Log("Test 1");
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // Create a new Ray object starting from the camera's position and poitning toward where the mouse cursor is currently located
        //     RaycastHit hit; // Initialize a new variable named hit with the type RaycastHit

        //     // Perform raycast to detect clicked object
        //     if (Physics.Raycast(ray, out hit))  // If ray intersects with any object in the Half Kitchen & Half Restaurant scene that has a collider
        //     {
        //         Debug.Log("Test 2");
        //         // Check if the object hit has a collider and is an ingredient
        //         // if (hit.collider != null)   // If the raycast hit an object that has a collider
        //         // {
        //             Debug.Log("Test 3");
        //             ingredient = hit.collider.gameObject; // Store the clicked ingredient
        //             AddIngredientToBowl();  // Call the function AddIngredientToBowl() which adds the clicked ingredient to the bowl
        //         // }
        //     }
        // }
    

        // if (!context.started) return;

        // var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        // if (!rayHit.collider) return;

        // GameObject selected_object = rayHit.collider.gameObject;
        // Debug.Log(selected_object.name);
        // AddIngredientToBowl();

        //    void OnTriggerEnter2D(Collider2D other)
        // {
        // if (other.CompareTag("Bowl")) //if the last selected ingredient hit the bowl
        // {
        //     Add_to_bowl(); //add the ingredient to the bowl (sprite transform + add to list) 
        //     check_recipe(); //create a function that checks if the right ingredient was added to the bowl
        // }
        // }

    }

    void AddIngredientToBowl()
    {
        if (ingredient != null && bowl != null) // If ingredient and bowl are assigned and contain references to GameObjects
        {
            // Logic to "add" the ingredient to the bowl
            Debug.Log($"Added {ingredient.name} to the bowl!"); // Output "Added *ingredient name* to the bowl" to the console during gameplay

            // Optionally, you can parent the ingredient to the bowl or move it
            ingredient.transform.parent = bowl.transform;   // Change the parent-child relationship between the ingredient GameObject and the bowl GameObject
            ingredient.transform.localPosition = new Vector3(0, 100f, 0); // Lower the Y-axis (e.g., -0.5)
            // ingredient.transform.localPosition = Vector3.zero; // Reset the local position of the ingredient GameObject to the origin (0, 0, 0) relative to its parent (the bowl)
        }
    }
}