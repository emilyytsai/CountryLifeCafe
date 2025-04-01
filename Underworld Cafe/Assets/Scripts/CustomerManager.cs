using UnityEngine;

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
    private int current_customer = 0;

    //customer script
    [SerializeField]
    private Customer customer_script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next_customer();
    }

    //move thru the array only when this function is called
    public void next_customer()
    {
        if (current_customer < customer_sprites.Length)
        {
            customer_sprite.sprite = customer_sprites[current_customer]; //swap the sprite

            //restart the enter->idle->leave loop
            customer_script.StartCoroutine(customer_script.Enter());//restart animations

            current_customer++;
        }
        else //once counter is 3
        {
            Debug.Log("day 1 complete");
            current_customer = 0;
            //later this is where the day summary will be setactive
        }
    }
}
