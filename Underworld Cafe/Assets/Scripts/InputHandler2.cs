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
    [SerializeField]
    private GameObject watering_can;

    //kitchen crops/ingedients
    public GameObject tomato_crop;
    public GameObject lettuce_crop;
    public GameObject strawberry_crop;
    public GameObject grape_crop;
    public GameObject cucumber_crop;


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
            if (last_selected == watering_can)
            {
                //deselect if player clicks on watering can again
                Reset();
                last_selected = null;
                selected_tool = Tool.None;
            }
            else
            {
                //selcting watering can
                Reset();
                highlight(selected_object);
                last_selected = watering_can;
                selected_tool = Tool.Water;
            }
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
        //soil click handling//
        //each soil obj has own soil script
        Soil soil_logic = selected_object.GetComponentInParent<Soil>();

        if (soil_logic != null)
        {
            //harvest//
            if (selected_object.CompareTag("Harvestable"))
            {
                soil_logic.harvest();
            }
            //seed//
            else if (selected_tool == Tool.Seed)
            {
                //assign coresponding crop to appear after harvest
                GameObject crop_to_give = null;
                switch (last_selected.name)
                {
                    case "Tomato Seeds":
                        crop_to_give = tomato_crop;
                        break;
                    case "Lettuce Seeds":
                        crop_to_give = lettuce_crop;
                        break;
                    case "Strawberry Seeds":
                        crop_to_give = strawberry_crop;
                        break;
                    case "Grape Seeds":
                        crop_to_give = grape_crop;
                        break;
                    case "Cucumber Seeds":
                        crop_to_give = cucumber_crop;
                        break;
                }

                soil_logic.plant_seed(crop_to_give);
            }
            //water//
            else if (selected_tool == Tool.Water)
            {
                soil_logic.water();
            }

            Reset();
            last_selected = null;
            //selected_tool = Tool.None; <- removed to handle watering multiple soil tiles w/o reslecting
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

    //moved
    // ///////////////////////////////////
    // //growing logic//
    // IEnumerator grow_plant()
    // {
    //     //make sure the obj is assigned in inspector
    //     if (growing1 == null || growing2 == null || growing3 == null)
    //         yield break;

    //     //hide prev stage, show nexrt
    //     growing1.SetActive(false);
    //     growing2.SetActive(true);
    //     yield return new WaitForSeconds(0.5f);

    //     growing2.SetActive(false);
    //     growing3.SetActive(true);

    //     growing3.tag = "Untagged";
    // }
}
