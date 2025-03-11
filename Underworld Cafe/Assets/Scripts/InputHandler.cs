using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    public GameObject last_selected;
    private Color initial_color;

    public CookingSystem cooking_system; //cooking sys script

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        GameObject selected_object = rayHit.collider.gameObject;
        Debug.Log(selected_object.name);

        //for cooking sys to work, the bowl cannot be the last_selected, so compare tags
        if (selected_object.CompareTag("Bowl"))
        {
            if (last_selected != null) //check if an ingredienet is selected
            {
                cooking_system.AddIngredientToBowl(last_selected); //add the last selected ingredient
                last_selected = null; //reset the last selected
            }
            return;
        }

        //ingredient selection
        if (selected_object.CompareTag("Ingredient"))
        {
            if (last_selected == selected_object)
            {
                reset();
                last_selected = null; //deselecting the object
                return;
            }

            if (last_selected != null)
            {
                reset();
            }
        }
        highlight(selected_object); //hihglight the last object that was clicked on

        last_selected = selected_object;
    }

    private void highlight(GameObject selected_object)
    {
        SpriteRenderer renderer = selected_object.GetComponent<SpriteRenderer>();

        if (renderer != null)
        {
            //store the initial color (color of the object)
            initial_color = renderer.color;

            //switch the color to white
            renderer.color = new Color(1f, 1f, 1f, 0.15f); //R,G,B,alpha 
        }
    }

    private void reset()
    {
        if (last_selected != null)
        {
            SpriteRenderer renderer = last_selected.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.color = initial_color; //reset to the initial color (remove highlight)
            }
        }
    }
}
