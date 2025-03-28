using UnityEngine;
using System.Collections; //for IEnum

public class Customer : MonoBehaviour
{
    //Customer Manager Script//
    //*deals with customer animations

    public Animator animator; //reference to animator

    //**customer_manager -> day1 (day 1 game manager)
    private Day1 game_manager1;

    //for defining which specific animator/customer
    public GameObject customer;

    //**customer_served bool moved to here
    public bool customer_served = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = customer.GetComponent<Animator>(); //must specify u want the customer animator
        game_manager1 = FindAnyObjectByType<Day1>();

        //customer enters//
        StartCoroutine(StartEnterAnimation()); //2 seconds after scene loads, the custmer will enter
        StartCoroutine(spawn_order()); //5 sec
    }
    
    public void CustomerServed()
    {
        customer_served = true;

        //show feedback after order is validated
        string feedback_message = game_manager1.orderCorrect ? "Thanks for the salad!" : "This isn't my order.";
        //if orderCorrect = true -> "Thanks for the salad!
        //if orderCorrect = false -> "This isn't my order."
        Debug.Log("showing feedback");

        UIManager.Instance.show_feedback(feedback_message);

        StartCoroutine(Leave());

        //destroy the patience bar/shadow & salad order after serving customer
        ////instead of destroying -> setactive(false) so these things can be reused
        UIManager.Instance.hide_order();
        Debug.Log("customer order gone");

        //also need to destroy the ingredients that got added to the bowl
        ////destroy -> setactive(false)
        UIManager.Instance.clear_salad();
        Debug.Log("salad reset");
    }
    
    IEnumerator StartEnterAnimation()
    {
        yield return new WaitForSeconds(2f); //2 second wait time
        animator.SetTrigger("EnterTrigger");//trigger the "EnterTrigger" in the animator
    }

    public IEnumerator Leave()
    {
        yield return new WaitForSeconds(2f);
        UIManager.Instance.hide_feedback();
        //trigger the "LeaveTrigger" in the animator to play the leaving animation
        if (animator != null)
        {
            animator.SetTrigger("LeaveTrigger");
        }

        Debug.Log("Customer has left");
        StartCoroutine(DestroyCustomer());
    }

    //wait 5 secs for displaying the cusotmers order
    IEnumerator spawn_order()
    {
        yield return new WaitForSeconds(5f);
        UIManager.Instance.show_order();
    }

    IEnumerator DestroyCustomer()
    {
        yield return new WaitForSeconds(3f); //wait 3 secs for the leave animation

        Destroy(gameObject); //used to be customer, but customer in this context is the animator
        game_manager1.next_customer(); //go thru customer array -> spawm next customer

        customer_served = false; //reset bool so next customer can be served
        Debug.Log("customer served bool reset");
    }
}
