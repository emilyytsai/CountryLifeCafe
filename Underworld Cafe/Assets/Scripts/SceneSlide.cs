using UnityEngine;
using UnityEngine.UI;

public class SceneSlide : MonoBehaviour
{
    [SerializeField]
    private RectTransform canvas;

    //buttons
    [SerializeField]
    private Button farm_button = null;
    [SerializeField]
    private Button back_button = null;

    // [SerializeField]
    // private float animation_speed = 5f;

    private bool on_farm = false;
    private Coroutine current_animation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        farm_button.onClick.AddListener(slide_farm);
        back_button.onClick.AddListener(slide_back);
    }

    void slide_farm()
    {
        if (!on_farm)
        {
            scene_slide();
        }
    }
    
    void slide_back()
    {
        if (on_farm)
        {
            scene_slide();
        }
    }

    void scene_slide()
    {
        if (current_animation != null)
        {
            StopCoroutine(current_animation);
        }

        float targetX = on_farm ? 0 : -1920;
        StartCoroutine(animate_pos(targetX));
        on_farm = !on_farm;
    }
    
    private System.Collections.IEnumerator animate_pos(float targetX)
    {
        Vector2 start_pos = canvas.anchoredPosition;
        Vector2 target_pos = new Vector2(targetX, start_pos.y);
      
        float duration = 0.6f; //animation length
        float time_elapsed = 0f;
        
        while (time_elapsed < duration)
        {
            time_elapsed += Time.deltaTime;
            float t = time_elapsed / duration; //interpolate from 0 to 1 over the duration

            canvas.anchoredPosition = Vector2.Lerp(start_pos, target_pos, t);
            yield return null;
        }
        
        canvas.anchoredPosition = target_pos;
        current_animation = null;
    }
}
