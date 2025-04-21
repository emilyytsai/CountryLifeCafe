using UnityEngine;
using System.Collections;

public class Soil : MonoBehaviour
{
    //sprites that simulate the growth animation
    public GameObject growing1;
    public GameObject growing2;
    public GameObject growing3;

    public Sprite wet_soil;
    public Sprite dry_soil;
    //[SerializeField]
    private SpriteRenderer sprite_renderer;

    //corresponding ingredient in kitchen
    [HideInInspector] 
    public GameObject kitchen_crop;

    private bool is_planted = false;
    private bool is_grown = false;

    private void Awake()
    {
        //get srpite again
        if (sprite_renderer == null)
        {
            sprite_renderer = GetComponent<SpriteRenderer>();
        }
    }

    //moved from the inputhandelr script
    ///////////////////////////////////
    //planting logic//
    public void plant_seed(GameObject crop)
    {
        if (is_planted) return;

        if (growing1 != null)
        {
            growing1.SetActive(true);
            this.gameObject.tag = "Planted"; //make clickable for watering
            is_planted = true;

            //store crop for harvest
            kitchen_crop = crop;
        }
    }

    //when player uses watering can
    public void water()
    {        
        if (is_grown) return; //u cant water only if the plant is already grown

        if (!is_planted)//for when player tries to water just soil
        {
            if (sprite_renderer != null && wet_soil != null)
            {
                sprite_renderer.sprite = wet_soil;
                StartCoroutine(dry());
            }
            return;
        }

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
        {
            yield break;
        }
        
        //hide prev stage, show nexrt
        //added another delay;doesnt grow right away
        yield return new WaitForSeconds(0.8f);

        growing1.SetActive(false);
        growing2.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        growing2.SetActive(false);
        growing3.SetActive(true);

        growing3.tag = "Harvestable";

        this.gameObject.tag = "Untagged"; //reset tag
        is_grown = true;
    }

    //after 3 secs wet soil will dry
    IEnumerator dry()
    {
        yield return new WaitForSeconds(3.0f);
        sprite_renderer.sprite = dry_soil;

        ////anothjer option
        // //dry soil if nothing got planted in 3 secs
        // if (!is_planted && sprite_renderer != null && dry_soil != null)
        // {
        //     sprite_renderer.sprite = dry_soil;
        // }
    }

    ///////////////////////////////////
    //harvesting logic//
    public void harvest()
    {
        if (!is_grown) return;

        //reset farm/soil tile
        growing1.SetActive(false);
        growing2.SetActive(false);
        growing3.SetActive(false);
        is_planted = false;
        is_grown = false;
        sprite_renderer.sprite = dry_soil;
        gameObject.tag = "Untagged";

        if (kitchen_crop != null)
        {
            kitchen_crop.SetActive(true);
        }

        kitchen_crop = null;
    }
}