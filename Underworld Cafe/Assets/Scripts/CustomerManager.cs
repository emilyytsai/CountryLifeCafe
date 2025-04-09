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

    //tracking customers
    private int customers_served = 0;
    private int customers_timed_out = 0;

    //customer script
    [SerializeField]
    private Customer customer_script;

    //for end of day, show day summary
    public GameObject day_summary;
    public GameObject prev_scene;

    //day summary text
    public TextMeshProUGUI summary_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //reset counter at start of day
        current_customer = -1;
        customers_served = 0;
        customers_timed_out = 0;

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

            //start/restart the enter->idle->leave loop
            StartCoroutine(start_animations());//restart animations
        }
        else //once counter is 3
        {
            //show day summary and hide the restuarnt/kitchen
            prev_scene.SetActive(false);
            day_summary.SetActive(true);
            summary_text.text = string.Format(
                "Good job! Here are your statistics for the day!\nMoney earned: ${0}\nCustomers served: {1}\nCustomers unhappy: {2}", 
                customers_served * 5, //temp implementation to get the earnings for the day -> get the actual player money later
                customers_served,
                customers_timed_out
            );

            Debug.Log("day complete");
        }
    }

    public void served_success()
    {
        customers_served++;
    }
    
    // Call this when customer times out
    public void customer_timed_out()
    {
        customers_timed_out++;
    }

    private IEnumerator start_animations()
    {
        yield return new WaitForSeconds(0.1f); //slight delay to prevent race conditions
        customer_script.StartCoroutine(customer_script.Enter());
    }
}
