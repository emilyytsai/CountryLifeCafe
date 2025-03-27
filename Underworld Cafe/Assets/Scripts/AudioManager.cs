// using UnityEngine;
// using UnityEngine.Audio;
// using System;

// public class AudioManager : MonoBehaviour
// {
//     public Sound[] sounds;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Awake()
//     {
//         foreach (Sound sound in sounds)
//         {
//             sound.source = gameObject.AddComponent<AudioSource>();

//             sound.source.clip = sound.clip;

//             sound.source.volume = sound.volume;
//             sound.source.pitch = sound.pitch;

//             sound.source.loop = sound.loop;
//         }
//     }

//     public void Play (string name)
//     {
//         Sound sound = Array.Find(sounds, sound => sound.name == name);
//         sound.source.Play();
//     }

//     public void Stop (string name)
//     {
//         Sound sound = Array.Find(sounds, sound => sound.name == name);
//         sound.source.Stop();
//     }

// }

// using UnityEngine;
// using UnityEngine.Audio;
// using UnityEngine.SceneManagement;
// using System;

// public class AudioManager : MonoBehaviour
// {
//     public Sound[] sounds;

//     private static AudioManager instance;

//     void Awake()
//     {
//         // Singleton pattern: only one AudioManager should exist.
//         if (instance == null)
//         {
//             instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//             return; // Exit if a duplicate exists.
//         }

//         // Set up AudioSources for each sound.
//         foreach (Sound sound in sounds)
//         {
//             sound.source = gameObject.AddComponent<AudioSource>();
//             sound.source.clip = sound.clip;
//             sound.source.volume = sound.volume;
//             sound.source.pitch = sound.pitch;
//             sound.source.loop = sound.loop;
//         }

//         // Subscribe to the scene loaded event.
//         SceneManager.sceneLoaded += OnSceneLoaded;
//     }

//     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     {
//         // Debug the loaded scene's name to verify it is what you expect.
//         Debug.Log("Scene loaded: " + scene.name);

//         // Be sure these strings exactly match your scene names in Build Settings.
//         // For example, if your scenes are named "MainMenu" and "GameObjective" (no spaces), adjust accordingly.
//         if (scene.name != "Main Menu" && scene.name != "Game Objective")
//         {
//             // Destroy the AudioManager if we're in any scene other than the allowed ones.
//             Destroy(gameObject);
//         }
//     }

//     public void Play(string name)
//     {
//         Sound sound = Array.Find(sounds, s => s.name == name);
//         if (sound == null)
//         {
//             Debug.LogWarning($"Sound: {name} not found!");
//             return;
//         }
//         sound.source.Play();
//     }

//     public void Stop(string name)
//     {
//         Sound sound = Array.Find(sounds, s => s.name == name);
//         if (sound == null)
//         {
//             Debug.LogWarning($"Sound: {name} not found!");
//             return;
//         }
//         sound.source.Stop();
//     }

//     void OnDestroy()
//     {
//         // Unsubscribe from scene loaded events.
//         SceneManager.sceneLoaded -= OnSceneLoaded;
//     }
// }

// using UnityEngine;
// using UnityEngine.Audio;
// using UnityEngine.SceneManagement;
// using System;
// using System.Linq;

// public class AudioManager : MonoBehaviour
// {
//     public Sound[] sounds;
//     private static AudioManager instance;

//     // List the scene names where you want the music to continue
//     // For any scene NOT in this list (Credits, Farm, Half Restaurant, etc),
//     // the persistent AudioManager will be destroyed.
//     private string[] persistentScenes = { "Main Menu", "Game Objective" };

//     void Awake()
//     {
//         // If an instance doesn't exist, set this one up.
//         if (instance == null)
//         {
//             instance = this;
//             // Check if the current scene is one where you want the music to persist.
//             if (persistentScenes.Contains(SceneManager.GetActiveScene().name))
//             {
//                 DontDestroyOnLoad(gameObject);
//             }
//         }
//         else
//         {
//             // If an instance already exists, remove this duplicate.
//             Destroy(gameObject);
//             return; 
//         }

//         // Set up AudioSources for each sound.
//         foreach (Sound sound in sounds)
//         {
//             sound.source = gameObject.AddComponent<AudioSource>();
//             sound.source.clip = sound.clip;
//             sound.source.volume = sound.volume;
//             sound.source.pitch = sound.pitch;
//             sound.source.loop = sound.loop;
//         }

//         // Subscribe to the scene loaded event.
//         SceneManager.sceneLoaded += OnSceneLoaded;
//     }

//     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     {
//         Debug.Log("Scene loaded: " + scene.name);

//         // If the newly loaded scene should not share the background music,
//         // then destroy this persistent AudioManager.
//         if (!persistentScenes.Contains(scene.name))
//         {
//             Destroy(gameObject);
//         }
//     }

//     public void Play(string name)
//     {
//         Sound sound = Array.Find(sounds, s => s.name == name);
//         if (sound == null)
//         {
//             Debug.LogWarning($"Sound: {name} not found!");
//             return;
//         }
//         sound.source.Play();
//     }

//     public void Stop(string name)
//     {
//         Sound sound = Array.Find(sounds, s => s.name == name);
//         if (sound == null)
//         {
//             Debug.LogWarning($"Sound: {name} not found!");
//             return;
//         }
//         sound.source.Stop();
//     }

//     void OnDestroy()
//     {
//         // Unsubscribe from the scene loaded event.
//         SceneManager.sceneLoaded -= OnSceneLoaded;
//     }
// }

// using UnityEngine;
// using UnityEngine.Audio;
// using UnityEngine.SceneManagement;
// using System;
// using System.Linq;

// public class AudioManager : MonoBehaviour
// {
//     public Sound[] sounds;
//     private static AudioManager instance;

//     // List of scenes where persistent (continuous) music should be played.
//     // When a scene not in this list loads, the persistent music will be stopped.
//     private string[] persistentScenes = { "Main Menu", "Game Objective" };

//     void Awake()
//     {
//         // Singleton pattern: only one AudioManager should exist.
//         if (instance == null)
//         {
//             instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//             return; // Exit if a duplicate exists.
//         }

//         // Set up AudioSources for each sound.
//         foreach (Sound sound in sounds)
//         {
//             sound.source = gameObject.AddComponent<AudioSource>();
//             sound.source.clip = sound.clip;
//             sound.source.volume = sound.volume;
//             sound.source.pitch = sound.pitch;
//             sound.source.loop = sound.loop;
//         }

//         // Subscribe to scene loaded events.
//         SceneManager.sceneLoaded += OnSceneLoaded;
//     }

//     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//     {
//         Debug.Log("Scene loaded: " + scene.name);

//         // If the scene is one where you want specialized music (Credits, Farm, Half Restaurant, etc.)
//         // then stop the persistent music.
//         if (!persistentScenes.Contains(scene.name))
//         {
//             // Stop all currently playing sounds to avoid playing unwanted music.
//             StopAllMusic();

//             // Optionally, automatically play scene-specific music.
//             // (Make sure the corresponding Sound with that name is set up in the inspector.)
//             if (scene.name == "Credits")
//             {
//                 Play("Party Waltz - Sir Cubworth");
//             }
//             else if (scene.name == "Farm")
//             {
//                 Play("FarmMusic");
//             }
//             else if (scene.name == "Half Restaurant")
//             {
//                 Play("HalfRestaurantMusic");
//             }
//             // You can add more scene-specific cases here.
//         }
//         else
//         {
//             // For persistent scenes, you can choose to restart or continue the persistent music.
//             // For example, for "Main Menu" or "Game Objective", you might want to play a specific track
//             // if nothing is playing, or resume the current one if it's already playing.
//             if (scene.name == "Main Menu")
//             {
//                 if (!IsPlaying("Sigma Slide - The Soundlings"))
//                 {
//                     StopAllMusic();
//                     Play("Sigma Slide - The Soundlings");
//                 }
//             }
//             else if (scene.name == "Game Objective")
//             {
//                 if (!IsPlaying("Sigma Slide - The Soundlings"))
//                 {
//                     StopAllMusic();
//                     Play("Sigma Slide - The Soundlings");
//                 }
//             }
//         }
//     }

//     public void Play(string name)
//     {
//         Sound sound = Array.Find(sounds, s => s.name == name);
//         if (sound == null)
//         {
//             Debug.LogWarning($"Sound: {name} not found!");
//             return;
//         }
//         if (sound.source == null)
//         {
//             Debug.LogWarning($"AudioSource for sound {name} is null!");
//             return;
//         }
//         sound.source.Play();
//     }

//     public void Stop(string name)
//     {
//         Sound sound = Array.Find(sounds, s => s.name == name);
//         if (sound == null)
//         {
//             Debug.LogWarning($"Sound: {name} not found!");
//             return;
//         }
//         if (sound.source != null)
//         {
//             sound.source.Stop();
//         }
//     }

//     public void StopAllMusic()
//     {
//         // Loop through all sounds and stop any that are playing.
//         foreach (Sound sound in sounds)
//         {
//             if (sound.source != null && sound.source.isPlaying)
//             {
//                 sound.source.Stop();
//             }
//         }
//     }

//     public bool IsPlaying(string name)
//     {
//         Sound sound = Array.Find(sounds, s => s.name == name);
//         if (sound == null) return false;
//         return sound.source != null && sound.source.isPlaying;
//     }

//     void OnDestroy()
//     {
//         // Unsubscribe from scene loaded events when this object is destroyed.
//         SceneManager.sceneLoaded -= OnSceneLoaded;
//     }
// }

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    // Group A persistent scenes: these scenes share one persistent track.
    public string[] persistentGroupA = { "Main Menu", "Game Objective" };

    // Group B persistent scenes: these scenes share another persistent track.
    public string[] persistentGroupB = { "Farm", "Half Kitchen & Half Window" };

    void Awake()
    {
        // Singleton pattern: only one AudioManager should exist.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes.
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Set up AudioSources for each sound.
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        // Subscribe to scene loaded events.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        // If the loaded scene is part of persistent Group A,
        // ensure that track "Sigma Slide - The Soundlings" is playing.
        if (persistentGroupA.Contains(scene.name))
        {
            if (!IsPlaying("Sigma Slide-The Soundlings"))
            {
                StopAllMusic();
                Play("Sigma Slide-The Soundlings");
            }
        }
        // If the loaded scene is part of persistent Group B,
        // ensure that track "Farm and Half Kitchen Music" is playing.
        else if (persistentGroupB.Contains(scene.name))
        {
            if (!IsPlaying("Kung Fu Love Tree-Quincas Moreira.mp3"))
            {
                StopAllMusic();
                Play("Kung Fu Love Tree-Quincas Moreira.mp3");
            }
        }
        else
        {
            // For any scene not in Group A or B, stop all music.
            StopAllMusic();
            // Optionally, play scene-specific music. For example:
            if (scene.name == "Credits")
            {
                Play("Party Waltz-Sir Cubworth.mp3");
            }
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        if (sound.source == null)
        {
            Debug.LogWarning($"AudioSource for sound {name} is null!");
            return;
        }
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return;
        }
        if (sound.source != null)
        {
            sound.source.Stop();
        }
    }

    public void StopAllMusic()
    {
        // Loop through all sounds and stop any that are playing.
        foreach (Sound sound in sounds)
        {
            if (sound.source != null && sound.source.isPlaying)
            {
                sound.source.Stop();
            }
        }
    }

    public bool IsPlaying(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null) return false;
        return sound.source != null && sound.source.isPlaying;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}