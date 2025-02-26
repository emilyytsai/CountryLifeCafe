using UnityEngine;
using System.Collections; //for IEnum

public class Customer : MonoBehaviour
{
    private MoneyScript moneyScript; //reference to money script
    private Animator animator; //reference to animator

    //private bool customer_served = false; *use this bool from the money script
    //referencing this function from money script
    //public void CustomerServed()
    //{
        //customer_served = true;
    //}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //moneyScript = FindObjectOfType<MoneyScript>(); //find the money script
        animator = GetComponent<Animator>();
        moneyScript = FindObjectOfType<MoneyScript>();
        StartCoroutine(StartEnterAnimation()); //2 seconds after scene loads, the custmer will enter
    }
    
    IEnumerator StartEnterAnimation()
    {
        yield return new WaitForSeconds(2f); //2 second wait time
        animator.SetTrigger("EnterTrigger");//trigger the "EnterTrigger" in the animator
    }

    // Update is called once per frame
    void Update()
    {
        if (moneyScript.IsCustomerServed()) //trigger leave animation after customer served
        {
            Leave();
            moneyScript.CustomerServed(); //reset bool
        }
    }

    public void CustomerServed()
    {
        moneyScript.CustomerServed(); //set bool to true
    }

    private void Leave()
    {
        //trigger the "LeaveTrigger" in the animator to play the leaving animation
        if (animator != null)
        {
            animator.SetTrigger("LeaveTrigger");
        }
        StartCoroutine(NextCustomer());  //spawn next customerr
    }

    IEnumerator NextCustomer()
    {
        yield return new WaitForSeconds(4f); //wait 3 secs for the leave animation + 1 sec transition
        //customer_served bool is set back to false using money script's reset function
        moneyScript.ResetCustomerServed(); //must be reset to avoid leave loop
        animator.SetTrigger("EnterTrigger");//trigger the "EnterTrigger" in the animator; for demo purposes this part is creating an infinite loop
    }
}
