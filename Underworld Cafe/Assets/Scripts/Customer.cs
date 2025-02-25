using UnityEngine;

public class Customer : MonoBehaviour
{
    private MoneyScript moneyScript; //reference to money script
    private Animator animator; //reference to animator

    private bool customer_served = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //moneyScript = FindObjectOfType<MoneyScript>(); //find the money script
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (customer_served) //trigger leave animation after customer served
        {
            Leave();
        }
    }

        public void CustomerServed()
    {
        customer_served = true;
    }

    private void Leave()
    {
        //trigger the "LeaveTrigger" in the animator to play the leaving animation
        if (animator != null)
        {
            animator.SetTrigger("LeaveTrigger");
        }
    }
}
