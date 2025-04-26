using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //UI Manager Script//
    public static UIManager Instance { get; private set; } //singleton pattern implementation

    //things that will be active when the customer enters
    public GameObject text_bubble;
    //public GameObject feedback; -> this is the game obj that holds the feedback text -> use the text reference directly
    public GameObject patience_bar;
    public GameObject patience_bar_shadow;

    //note** manually assign the salad order
    public GameObject salad_order;

    //for ingredients to show up inside bowl
    public GameObject tomato_bowl;
    public GameObject lettuce_bowl;
    public GameObject strawberry_bowl;
    public GameObject grape_bowl;
    public GameObject cucumber_bowl;
    
    //feedback text
    public TextMeshProUGUI feedback_text;

    //buttons - arent interactable until customer order spawns
    //for serve button logic implementation as well
	[SerializeField]
	private Button serve_button = null;
    [SerializeField]
	private Button farm_button = null;

    // //disable ingredient interaction before game start
    // [SerializeField]
	// private GameObject input;

    //script references
    //game manager
    [SerializeField]
    private GameManager game_manager;
    [SerializeField]
    private PatienceTimer patience_timer;

    //singleton pattern implementation = only one instance of the ui manager that can be used in any script
    //prevents multiple copies of ui managers to be made
    //reference this in other scripts using "UIManager.Instance.'method name'();"
    //now any ui from the kitchen will be persistent when u switch back and forth from the farm
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else //destroy duplicate instance if found
        {
            Destroy(gameObject);
        }

        //becomes interactable after the order is shown
        serve_button.interactable = false;
        farm_button.interactable = false;
        // input.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //make srue money is persistent
        if (MoneyScript.Instance != null)
        {
            MoneyScript.Instance.moneyText = GameObject.Find("Money Text").GetComponent<TextMeshProUGUI>();
            MoneyScript.Instance.UpdateMoneyText();
        }

        //still not interactable at start -> only after order is shown
        serve_button.interactable = false;
        farm_button.interactable = false;
        // input.SetActive(false);

        //for serve button
        serve_button.onClick.AddListener(serve_pressed);
    }

    //methods for showing and hiding ui//

    //customer's salad order
    public void show_order()
    {
        //spawn in the text bubble, salad order, & patience bar/shadow
        text_bubble.SetActive(true);
        salad_order.SetActive(true);
        patience_bar.SetActive(true);
        patience_bar_shadow.SetActive(true);

        //u can now use the buttons/ingredients
        serve_button.interactable = true;
        farm_button.interactable = true;
        // input.SetActive(true);

        //reset timer for next customer
        patience_timer.reset_timer();
    }

    public void hide_order()
    {
        salad_order.SetActive(false);
        patience_bar.SetActive(false);
        patience_bar_shadow.SetActive(false);
        serve_button.interactable = false;
    }
    ///////////////////////////////////////

    //feedback text
    public void show_feedback(string message)
    {
        feedback_text.text = message;
        feedback_text.gameObject.SetActive(true);
    }

    public void hide_feedback() //also gets rid of the text bubble 
    {
        if (feedback_text != null && feedback_text.gameObject != null)
        {
            feedback_text.gameObject.SetActive(false);
            text_bubble.SetActive(false);
        }
    }
    ///////////////////////////////////////

    //reset the salad for next order
    public void clear_salad()
    {
        tomato_bowl.SetActive(false);
        lettuce_bowl.SetActive(false);
        strawberry_bowl.SetActive(false);
        grape_bowl.SetActive(false);
        cucumber_bowl.SetActive(false);
    }

    ///////////////////////////////////////////////////////////////
    //serve button logic - what is gonna happen when we press serve
    private void serve_pressed()
    {
        game_manager.validate_order();
    }
}
