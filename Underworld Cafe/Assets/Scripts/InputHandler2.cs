using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class InputHandler2 : MonoBehaviour
{
    //Input Handler for farm + farming system//

    private Camera _mainCamera;

    public GameObject last_selected;
    private Color initial_color;

    public GameObject soil;
    //private GameObject seed;
    private GameObject watering_can;

    // //planted seeds
    // public GameObject tomato_planted = null;
    // public GameObject lettuce_planted = null;

    // //fully grown crops
    // //(triggered after watered)
    // public GameObject tomato_grown = null;
    // public GameObject lettuce_grown = null;

    public GameObject growing1 = null;
    public GameObject growing2 = null;
    public GameObject growing3 = null;

    private enum Tool 
    {
        None, Seed, Water
    }

    private Tool selected_tool = Tool.None;

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

        //watering can
        if (selected_object == watering_can)
        {
            selected_tool = Tool.Water;
            highlight(selected_object);
            last_selected = watering_can;

            return;
        }

        //seed select
        if (selected_object.CompareTag("Seed"))
        {
            //deselect if player cliskc on same seed again
            if (last_selected == selected_object)
            {
                Reset();
                last_selected = null;
                selected_tool = Tool.None;
                return;
            }

            Reset();
            highlight(selected_object);

            //save seed obj, switch tool to seed
            last_selected = selected_object;
            selected_tool = Tool.Seed;
            return;
        }
        /////////////////////////
        //handle planting logic//
        if (selected_object.CompareTag("Soil") && selected_tool == Tool.Seed)
        {
            if (last_selected != null)
            {
                plant_seed();
                Reset();
                last_selected = null;
                selected_tool = Tool.None;//reset tool
            }
            return;
        }

        /////////////////////////
        //water after plating//
        if (selected_tool == Tool.Water && selected_object.CompareTag("Planted"))
        {
            StartCoroutine(grow_plant());

            Reset();
            last_selected = null;
            selected_tool = Tool.None;
            return;
        }
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

    ///////////////////////////////////
    //planting logic//
    void plant_seed()
    {
        if (growing1 != null)
        {
            growing1.SetActive(true);

            growing1.tag = "Planted";
        }
    }

    ///////////////////////////////////
    //growing logic//
    IEnumerator grow_plant()
    {
        //make sure the obj is assigned in inspector
        if (growing1 == null || growing2 == null || growing3 == null)
            yield break;

        //hide prev stage, show nexrt
        growing1.SetActive(false);
        growing2.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        growing2.SetActive(false);
        growing3.SetActive(true);

        growing3.tag = "Untagged";
    }
}
