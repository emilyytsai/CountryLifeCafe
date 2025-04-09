using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    //Order Manager Script//
    //this script controls the flow of customer's salad orders
    //we are changing salad sprite for each custmer

    //salad order container
    ////array of salad sprites
    public Sprite[] salad_sprites;
    public Image salad;
    private int current_salad = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        salad.sprite = null; //placeholder null sprite
    }

    //move thru the array only when this function is called
    public void next_order()
    {
        if (current_salad < salad_sprites.Length - 1)
        {
            current_salad++;
            salad.sprite = salad_sprites[current_salad]; //swap the sprite
        }
    }
}
