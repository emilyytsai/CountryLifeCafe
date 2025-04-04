using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler2 : MonoBehaviour
{
    //Input Handler for farm + farming system//

    private Camera _mainCamera;

    public GameObject last_selected;
    private Color initial_color;

    public GameObject soil;
    private GameObject seed;
    private GameObject watering_can;

    //planted seeds
    public GameObject tomato_planted = null;
    public GameObject lettuce_planted = null;

    //fully grown crops
    //(triggered after watered)
    public GameObject tomato_grown = null;
    public GameObject lettuce_grown = null;

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

        //compare tags
        if (selected_object.CompareTag("Soil"))
        {
            if (last_selected != null)
            {
                plant_seed(last_selected);
                last_selected = null; //reset the last selected
            }
            return;
        }

        if (selected_object.CompareTag("Seed"))
        {
            if (last_selected == selected_object)
            {
                Reset();
                last_selected = null; //deselecting the object
                return;
            }

            if (last_selected != null)
            {
                Reset();
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

    private void Reset()
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

    ////////////////////////
    //farming system logic//
    public void plant_seed(GameObject seed)
    {
        if (seed != null && soil != null)
        {
            string seed_name = seed.name;
            Debug.Log($"planted {seed.name}");
            enable_seeds(seed_name);
        }
    }

    void enable_seeds(string seed_name)
    {
        switch (seed_name)
        {
            case "Tomato Seeds":
                enable_T_seeds();
                break;

            case "Lettuce Seeds":
                enable_L_seeds();
                break;

            default:
                break;
        }
    }

    void enable_T_seeds()
    {
        if (tomato_planted != null)
        {
            tomato_planted.SetActive(true);
        }
    }

    void enable_L_seeds()
    {
        if (lettuce_planted != null)
        {
            lettuce_planted.SetActive(true);
        }
    }
}
