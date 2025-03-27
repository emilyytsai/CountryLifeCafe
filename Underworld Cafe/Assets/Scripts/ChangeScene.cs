using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string Name; // Name of the scene to load
    private AudioManager audio_manager;
    [SerializeField] RectTransform fader;

    private void Start()
    {
        audio_manager = FindAnyObjectByType<AudioManager>();
    }

    public void ChangeScene()
    {
        StartCoroutine(WaitAndChangeScene()); // Start the coroutine to wait before changing the scene
    }

    // public void OpenCreditsScene() {
    //     fader.gameObject.SetActive(true);
    //     LeanTween.scale(fader, Vector3.zero, 0f);
    //     LeanTween.scale(fader, new Vector3 (1, 1, 1), 0.1f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => {
    //     });
    // }

    public void OpenCreditsScene() {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0f); // Start at full size
        LeanTween.scale(fader, Vector3.zero, 0.2f) // Shrink to zero
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() => {
                // Perform any actions after the animation completes
            });
    }

    public void OpenGameObjectiveScene() {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0f); // Start at full size
        LeanTween.scale(fader, Vector3.zero, 0.2f) // Shrink to zero
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() => {
                // Perform any actions after the animation completes
            });
    }

    public void click_sound()
    {
        audio_manager.Play("Button Click"); // Play the button click sound effect
    }

    public IEnumerator WaitAndChangeScene()
    {
        click_sound(); // Play the sound effect
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        SceneManager.LoadScene(Name); // Load the new scene after the delay
    }
}
// using System.Collections;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class MainMenu : MonoBehaviour
// {
//     [SerializeField]
//     private string Name; // Name of the scene to load

//     private AudioManager audio_manager;

//     [SerializeField] 
//     RectTransform fader;

//     private void Start()
//     {
//         audio_manager = FindAnyObjectByType<AudioManager>();

//         if (audio_manager == null)
//         {
//             Debug.LogWarning("AudioManager not found in the scene.");
//         }
//         else
//         {
//             Debug.Log("AudioManager found: " + audio_manager.name);
//         }
//     }

//     // This is the function you call from your button's OnClick event.
//     public void ChangeScene()
//     {
//         Debug.Log("ChangeScene() called. Preparing to load scene: " + Name);
//         StartCoroutine(WaitAndChangeScene());
//     }

//     public void click_sound()
//     {
//         if (audio_manager != null)
//         {
//             audio_manager.Play("Button Click"); // Play the button click sound effect
//         }
//         else
//         {
//             Debug.LogWarning("AudioManager is null. Cannot play click sound.");
//         }
//     }

//     public IEnumerator WaitAndChangeScene()
//     {
//         click_sound(); // Play the sound effect
//         yield return new WaitForSeconds(0.1f); // Wait for a short period

//         // Log the scene change attempt.
//         Debug.Log("Loading scene: " + Name);
//         SceneManager.LoadScene(Name); // Load the new scene after delay
//     }
// }