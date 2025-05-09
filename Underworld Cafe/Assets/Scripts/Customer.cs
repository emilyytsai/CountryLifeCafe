using UnityEngine;
using System.Collections; //for IEnum

public class Customer : MonoBehaviour
{
    //Customer Script//
    //*deals with customer animations

    public Animator animator; //reference to animator

    //script references
    //game manager
    [SerializeField]
    private GameManager game_manager;
    [SerializeField]
    private CustomerManager customer_manager;
    [SerializeField]
    private CookingSystem cooking_system;
    [SerializeField]
    private OrderManager order_manager;
    [SerializeField]
    private PatienceTimer patience;

    //for defining which specific animator/customer
    public GameObject customer;

    //flags
    //**customer_served bool moved to here
    public bool customer_served = false;
    private bool IsLeaving = false;

    public int customer_satisfaction = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = customer.GetComponent<Animator>(); //must specify u want the customer animator
    }
    
    public void CustomerServed()
    {
        customer_served = true;

        //destroy the patience bar/shadow & salad order after serving customer
        ////instead of destroying -> setactive(false) so these things can be reused
        UIManager.Instance.hide_order();
        Debug.Log("customer order gone");

        //also need to destroy the ingredients that got added to the bowl
        ////destroy -> setactive(false)
        UIManager.Instance.clear_salad();
        Debug.Log("salad reset");

        //customer leaves//
        //only call Leave once** so there are no double customer jumps
        if (!IsLeaving || patience.timer <= 0)
        {
            IsLeaving = true;
            StartCoroutine(Leave());
        }
    }
    
    public IEnumerator Enter()
    {
        StartCoroutine(spawn_order()); //after 5 sec

        //reset prev triggers
        animator.Rebind();
        animator.Update(0);

        animator.SetTrigger("EnterTrigger");//trigger the "EnterTrigger" in the animator
        yield return new WaitForSeconds(2.2f); //2 second wait time
        animator.SetTrigger("IdleTrigger"); //trigger the "IdleTrigger" in the animator
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
        //StartCoroutine(DestroyCustomer());
        yield return new WaitForSeconds(3f); //wait 3 secs for the leave animation

        //reset flag
        IsLeaving = false;

        //reset the current_recipe list
        cooking_system.current_recipe.Clear();

        //spawn next customer
        customer_manager.next_customer();
    }

    //wait 3 secs for displaying the cusotmers order
    IEnumerator spawn_order()
    {
        yield return new WaitForSeconds(3f);
        UIManager.Instance.show_order();
        order_manager.next_order();
    }
}
