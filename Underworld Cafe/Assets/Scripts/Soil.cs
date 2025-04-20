using UnityEngine;
using System.Collections;

public class Soil : MonoBehaviour
{
    //sprites that simulate the growth animation
    public GameObject growing1;
    public GameObject growing2;
    public GameObject growing3;

    public Sprite wet_soil;
    [SerializeField]
    private SpriteRenderer sprite_renderer;

    private bool is_planted = false;
    private bool is_grown = false;

    //moved from the inputhandelr script
    ///////////////////////////////////
    //planting logic//
    public void plant_seed()
    {
        if (is_planted) return;

        if (growing1 != null)
        {
            growing1.SetActive(true);

            growing1.tag = "Planted"; //make clickable for watering
        }
    }

    //when player uses watering can
    public void water()
    {
        if (!is_planted || is_grown) return;

        if (sprite_renderer != null && wet_soil != null)
        {
            sprite_renderer.sprite = wet_soil;
        }


        StartCoroutine(grow_plant());
    }

    //also moved from the inputhander script
    ///////////////////////////////////
    //growing logic//
    IEnumerator grow_plant()
    {
        //make sure the obj is assigned in inspector
        if (growing1 == null || growing2 == null || growing3 == null)
            yield break;

        //hide prev stage, show nexrt
        growing1.SetActive(false);
        growing2.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        growing2.SetActive(false);
        growing3.SetActive(true);

        growing3.tag = "Untagged";
        is_grown = true;
    }
}
