using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;   //  The library System.Collections.Generic is needed for list
using System.Linq;  //for SequenceEqual

public class GameManager : MonoBehaviour
{
    //Game Manager Script//

    //script references
    [SerializeField]
    private Recipes recipe; //reference to recipes script
    [SerializeField]
    private CookingSystem cookingSystem; //reference to cooking system script
    [SerializeField]
    private Customer customer; //reference to customer script

    //code flow//
    //validate_order()

    public void validate_order()
    {
        string feedback_message;

        //if the player presses serve w/o putting anything int he bowl
        if (cookingSystem.current_recipe.Count == 0)
        {
            feedback_message = "Um, where is my salad?";
            UIManager.Instance.show_feedback(feedback_message);
            customer.CustomerServed();
            return;
        }

        //convert salad to a hashset -> order of salad no longer matters
        //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1.setequals?view=net-9.0

        HashSet<string> recipe_set = new HashSet<string>(cookingSystem.current_recipe);

        //for handling ten token salads -> use any and setequals
        if (recipe.five_token_recipes.Any(r => new HashSet<string>(r).SetEquals(cookingSystem.current_recipe)))
        {
            recipe.recipe_value(cookingSystem.current_recipe);
            feedback_message = "Thanks for the salad!";

        }
        else if (recipe.ten_token_recipes.Any(r => new HashSet<string>(r).SetEquals(cookingSystem.current_recipe)))
        {
            recipe.recipe_value(cookingSystem.current_recipe);
            feedback_message = "Wow! Thanks for the great salad!";

        }
        else
        {
            Debug.Log("Salad is wrong order");
            feedback_message = "This isn't my order.";
        }

        UIManager.Instance.show_feedback(feedback_message);
        customer.CustomerServed();
    }
}
