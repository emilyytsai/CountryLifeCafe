using UnityEngine;
using System.Collections; //for IEnum
using TMPro;

public class CustomerManager : MonoBehaviour
{
    //Customer Manager Script//
    //this script controls the flow of our customers array
    //we are changing customer appearance when its the next customer

    //customer container
    ////array of customer sprites
    ////all customers have same behavior just different appearance/sprite
    public Sprite[] customer_sprites;
    public SpriteRenderer customer_sprite;
    //customer counter
    private int current_customer = -1;

    //customer script
    [SerializeField]
    private Customer customer_script;

    [SerializeField]
    private MoneyScript money_script;

    //for end of day, show day summary
    public GameObject day_summary;
    public GameObject prev_scene;

    //day summary text
    public TextMeshProUGUI summary_text;

    //every customer gets their own timer
    // public GameObject timer_prefab; 
    // public Transform patience_bar_shadow;
    // [SerializeField]
    // private GameObject current_timer;
    // private GameObject new_timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next_customer();
    }

    //move thru the array only when this function is called
    public void next_customer()
    {
        if (current_customer + 1 < customer_sprites.Length)
        {
            current_customer++;
            customer_sprite.sprite = customer_sprites[current_customer]; //swap the sprite

            //prevent stuck animations
            customer_script.animator.Rebind();
            customer_script.animator.Update(0);

            // //get rid of old timer
            // if (current_timer != null)
            // {
            //     Destroy(current_timer);
            // }

            // //create a new patience timer for each new customer
            // new_timer = Instantiate(timer_prefab, patience_bar_shadow);
            // new_timer.SetActive(true);

            //start/restart the enter->idle->leave loop
            StartCoroutine(start_animations());//restart animations
        }
        else //once counter is 3
        {
            //show day summary and hide the restuarnt/kitchen
            prev_scene.SetActive(false);
            day_summary.SetActive(true);
            Debug.Log("day 1 complete");
            summary_text.text = "Good job! Here are your statistics for the day!\n\nTotal Money Earned: " + money_script.tokens + "\nCustomers Satisfied: " + customer_script.customer_satisfaction
                                + "\nCustomers Unhappy: " + (customer_sprites.Length - customer_script.customer_satisfaction);
        }
    }

    private IEnumerator start_animations()
    {
        yield return new WaitForSeconds(0.1f); //slight delay to prevent race conditions
        customer_script.StartCoroutine(customer_script.Enter());
    }
}
