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
    
    //feedback text
    public TextMeshProUGUI feedback_text;

    //buttons - arent interactable until customer order spawns
    //for serve button logic implementation as well
	[SerializeField]
	private Button serve_button = null;
    [SerializeField]
	private Button farm_button = null;

    //make the money persistent**
    [SerializeField]
    public TextMeshProUGUI money = null;

    //script references
    //game manager 
    private Day1 day1;

    //singleton pattern implementation = only one instance of the ui manager that can be used in any script
    //prevents multiple copies of ui managers to be made
    //reference this in other scripts using "UIManager.Instance.'method name'();"
    //now any ui from the kitchen will be persistent when u switch back and forth from the farm
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else //destroy duplicate instance if found
        {
            Destroy(gameObject);
        }

        //becomes interactable after the order is shown
        serve_button.interactable = false;
        farm_button.interactable = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        day1 = FindAnyObjectByType<Day1>();
        // Check the current scene name
        // if (SceneManager.GetActiveScene().name == "DaySummary")
        // {
        //     // Perform actions specific to "MyScene"
        //     Debug.Log("Running actions for Day Summary");
        //     feedback_text.text = "Good job! Here are your statistics for the day!/nMoney earned:/nCustomers served:n/Customers unhappy";        

        // }
        // else if (SceneManager.GetActiveScene().name == "Half Kitchen & Half Window")
        // {
        //     // Perform actions specific to "AnotherScene"
        //     Debug.Log("Running actions for Kitchen");
        //     //**when we fix the timer -> feedback_text.text = "You're taking too long, I'm leaving!";     
        //     if (day1.orderCorrect)
        //     {
        //         feedback_text.text = "Thanks for the salad!";     
        //     }
        //     else 
        //     {
        //         feedback_text.text = "This isn't my order.";
        //     }
        // }

        //still not interactable at start -> only after order is shown
        serve_button.interactable = false;
        farm_button.interactable = false;

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

        //u can now use the buttons
        serve_button.interactable = true;
        farm_button.interactable = true;
    }

    public void hide_order()
    {
        salad_order.SetActive(false);
        patience_bar.SetActive(false);
        patience_bar_shadow.SetActive(false);
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
    }

    ///////////////////////////////////////////////////////////////
    //serve button logic - what is gonna happen when we press serve
    private void serve_pressed()
    {
        day1.FirstCustomer();
    }
}
