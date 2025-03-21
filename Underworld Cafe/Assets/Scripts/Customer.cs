using UnityEngine;
using System.Collections; //for IEnum

public class Customer : MonoBehaviour
{
    private MoneyScript moneyScript; //reference to money script
    private Animator animator; //reference to animator
    public GameObject customer;

    //things that will spawn/be destroyed when the customer enters
    public GameObject text_bubble;
    public GameObject salad_order;
    public GameObject feedback;
    public GameObject patience_bar;
    public GameObject patience_bar_shadow;

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
        Destroy(patience_bar);
        Destroy(patience_bar_shadow);
        Destroy(salad_order);
        Debug.Log("gone");

        //also need to destroy the ingredients that got added to the bowl
        Destroy(tomato_bowl);
        Destroy(lettuce_bowl);
        Debug.Log("salad reset");
    }

    IEnumerator Leave()
    {
        yield return new WaitForSeconds(2f);
        Destroy(text_bubble);
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
        Destroy(customer);
    }

    //IEnumerator NextCustomer()
    //{
        //yield return new WaitForSeconds(4f); //wait 3 secs for the leave animation + 1 sec transition
        //customer_served bool is set back to false using money script's reset function
        //moneyScript.ResetCustomerServed(); //must be reset to avoid leave loop
        //animator.SetTrigger("EnterTrigger");//trigger the "EnterTrigger" in the animator; for demo purposes this part is creating an infinite loop
    //}
}
