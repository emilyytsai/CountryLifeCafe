// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class MainMenu : MonoBehaviour
// {
//     [SerializeField]
//     private string Name; // Name of the scene to load
//     private AudioManager audio_manager;
//     [SerializeField] RectTransform fader;

//     private void Start()
//     {
//         audio_manager = FindAnyObjectByType<AudioManager>();
//     }

//     public void ChangeScene()
//     {
//         StartCoroutine(WaitAndChangeScene()); // Start the coroutine to wait before changing the scene
//     }

//     // public void OpenCreditsScene() {
//     //     fader.gameObject.SetActive(true);
//     //     LeanTween.scale(fader, Vector3.zero, 0f);
//     //     LeanTween.scale(fader, new Vector3 (1, 1, 1), 0.1f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => {
//     //     });
//     // }

//     public void OpenCreditsScene() {
//         fader.gameObject.SetActive(true);
//         LeanTween.scale(fader, new Vector3(1, 1, 1), 0f); // Start at full size
//         LeanTween.scale(fader, Vector3.zero, 0.2f) // Shrink to zero
//             .setEase(LeanTweenType.easeInOutQuad)
//             .setOnComplete(() => {
//                 // Perform any actions after the animation completes
//             });
//     }

//     public void OpenGameObjectiveScene() {
//         fader.gameObject.SetActive(true);
//         LeanTween.scale(fader, new Vector3(1, 1, 1), 0f); // Start at full size
//         LeanTween.scale(fader, Vector3.zero, 0.2f) // Shrink to zero
//             .setEase(LeanTweenType.easeInOutQuad)
//             .setOnComplete(() => {
//                 // Perform any actions after the animation completes
//             });
//     }

//     public void click_sound()
//     {
//         audio_manager.Play("Button Click"); // Play the button click sound effect
//     }

//     public IEnumerator WaitAndChangeScene()
//     {
//         click_sound(); // Play the sound effect
//         yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
//         SceneManager.LoadScene(Name); // Load the new scene after the delay
//     }
// }

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
        // Find the AudioManager in the scene.
        audio_manager = FindAnyObjectByType<AudioManager>();
    }

    public void ChangeScene()
    {
        // This is the function you'll attach to your button OnClick.
        StartCoroutine(WaitAndChangeScene());
    }

    // Optional fader animations for Credits and Game Objective scenes.
    public void OpenCreditsScene() {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0f); // Fader starts fully scaled
        LeanTween.scale(fader, Vector3.zero, 0.2f) // Shrinks to zero in 0.2 seconds
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() => {
                // Additional actions can be placed here after the animation.
            });
    }

    public void OpenGameObjectiveScene() {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0f);
        LeanTween.scale(fader, Vector3.zero, 0.2f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() => {
                // Additional actions can be placed here after the animation.
            });
    }

    public void click_sound()
    {
        // This calls the AudioManager to play your "Button Click" sound.
        audio_manager.Play("Button Click");
    }

    public IEnumerator WaitAndChangeScene()
    {
        // Play the click sound.
        click_sound();
        // Wait a short period (0.1 sec); gives the sound time to start.
        yield return new WaitForSeconds(0.1f);
        // Then load the scene specified by the Name field.
        SceneManager.LoadScene(Name);
    }
}