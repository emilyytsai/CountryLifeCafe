using UnityEngine;
using System.Collections; //for IEnum

public class Customer : MonoBehaviour
{
    private MoneyScript moneyScript; //reference to money script
    private Animator animator; //reference to animator
    private CustomerManager customer_manager; //customer manager script

    //for defining which specific animator/customer
    public GameObject customer;

    //things that will be active when the customer enters
    public GameObject text_bubble;
    public GameObject feedback;
    public GameObject patience_bar;
    public GameObject patience_bar_shadow;

    //note** manually assign the salad order
    public GameObject salad_order;

    //for ingredients to show up inside bowl
    public GameObject tomato_bowl;
    public GameObject lettuce_bowl;

    //private bool customer_served = false; *use this bool from the money script
    //referencing this function from money script
    //public void CustomerServed()
    //{
        //customer_served = true;
    //}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = customer.GetComponent<Animator>(); //must specify u want the customer animator
        moneyScript = FindAnyObjectByType<MoneyScript>();
        customer_manager = FindAnyObjectByType<CustomerManager>();

        StartCoroutine(StartEnterAnimation()); //2 seconds after scene loads, the custmer will enter
        StartCoroutine(spawn_order()); //5 sec
    }
    
    IEnumerator StartEnterAnimation()
    {
        yield return new WaitForSeconds(2f); //2 second wait time
        animator.SetTrigger("EnterTrigger");//trigger the "EnterTrigger" in the animator
    }

    IEnumerator spawn_order()
    {
        yield return new WaitForSeconds(5f);
        //spawn in the text bubble, salad order, & patience bar/shadow
        text_bubble.SetActive(true);
        salad_order.SetActive(true);
        patience_bar.SetActive(true);
        patience_bar_shadow.SetActive(true);
    }

    public void CustomerServed()
    {
        moneyScript.CustomerServed(); //set bool to true
        feedback.SetActive(true);
        StartCoroutine(Leave());

        //destroy the patience bar/shadow, salad order, & text bubble after serving customer
        ////instead of destroying -> setactive(false) so these things can be reused
        patience_bar.SetActive(false);
        patience_bar_shadow.SetActive(false);
        salad_order.SetActive(false);
        Debug.Log("gone");

        //also need to destroy the ingredients that got added to the bowl
        ////destroy -> setactive(false)
        tomato_bowl.SetActive(false);
        lettuce_bowl.SetActive(false);
        Debug.Log("salad reset");
    }

    IEnumerator Leave()
    {
        yield return new WaitForSeconds(2f);
        text_bubble.SetActive(false);
        //trigger the "LeaveTrigger" in the animator to play the leaving animation
        if (animator != null)
        {
            animator.SetTrigger("LeaveTrigger");
        }
        //StartCoroutine(NextCustomer());  //spawn next customerr
        Debug.Log("Customer has left");
        StartCoroutine(DestroyCustomer());
    }

    IEnumerator DestroyCustomer()
    {
        yield return new WaitForSeconds(3f); //wait 3 secs for the leave animation

        Destroy(gameObject); //used to be customer, but customer in this context is the animator
        customer_manager.next_customer(); //go thru customer array -> spawm next customer

        moneyScript.ResetCustomerServed(); //reset bool so next customer can be served
        Debug.Log("customer served bool reset");
    }

    //IEnumerator NextCustomer()
    //{
        //yield return new WaitForSeconds(4f); //wait 3 secs for the leave animation + 1 sec transition
        //customer_served bool is set back to false using money script's reset function
        //moneyScript.ResetCustomerServed(); //must be reset to avoid leave loop
        //animator.SetTrigger("EnterTrigger");//trigger the "EnterTrigger" in the animator; for demo purposes this part is creating an infinite loop
    //}
}
