// using UnityEngine;

// public class BackgroundMusic : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     private AudioSource audioSource;
//     void Start()
//     {
//         audioSource = GetComponent<AudioSource>();
//         PlayMusic();
//     }

//     public void PlayMusic()
//     {
//         if (!audioSource.isPlaying)
//         {
//             audioSource.Play();
//         }
//     }

//     // Update is called once per frame
//     public void StopMusic()
//     {
//         if (audioSource.isPlaying)
//         {
//             audioSource.Stop();
//         }
//     }
// }

using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
  private AudioSource audioSource;
  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    PlayMusic();
  }
  
  public void PlayMusic()
  {
    if (!audioSource.isPlaying)
    {
      audioSource.Play();
    }
  }
  
  public void StopMusic()
  {
    if (audioSource.isPlaying)
    {
      audioSource.Stop();
    }
  }
}