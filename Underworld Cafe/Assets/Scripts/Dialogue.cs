using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Commands;
using System;
using Unity.VisualScripting;
using Object = UnityEngine.Object;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Text))]
public class Dialogue : MonoBehaviour
{
    private Queue<string> dialogueQueue;
    public GameObject blackBackground;
    public GameObject sunGlow;
    public TMP_Text reaperName;
    public TMP_Text buttonText;
    public GameObject reaperImage;
    private TMP_Text _textBox;
    
    //Basic Typewriter Functionality
    private int _currentVisibleCharacterIndex;
    private Coroutine _typewriterCoroutine;
    private bool _readyForNewText = true;

    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _interpunctuationDelay;

    [Header("Typewriter Settings")]
    [SerializeField] private float charactersPerSecond = 5;
    [SerializeField] private float interpunctuationDelay = 0.5f;

    //Skipping Functionality
    public bool CurrentlySkipping { get; private set; }
    private WaitForSeconds _skipDelay;

    [Header("Skip options")]
    [SerializeField] private bool quickSkip;
    [SerializeField] [Min(1)] private int skipSpeedup = 5;

    //Event Functionality
    private WaitForSeconds _textboxFullEventDelay;
    [SerializeField] [Range(0.1f, 0.5f)] private float sendDoneDelay = 0.5f;

    public static event Action CompleteTextRevealed;
    public static event Action<char> CharacterRevealed;


    void Start()
    {
        dialogueQueue = new Queue<string>();

        dialogueQueue.Enqueue("Where the hell are you? While your home isn’t some five star hotel, it’s definitely not the shabby farm you see in front of you.");
        dialogueQueue.Enqueue("You brush away the dirt clinging to your clothes from the soil patch you found yourself on. You look around and lock eyes with the figure leaning against a tree. Your heart jumps.");
        dialogueQueue.Enqueue("Hello.");
        dialogueQueue.Enqueue("Uh, hi? Who are you?");
        dialogueQueue.Enqueue("You can just call me Reaper. You might be wondering why you’re here. To be honest, I’m just as confused as you are. You’re definitely not supposed to be here, at least not now anyways.");
        dialogueQueue.Enqueue("What does that even mean? Where even is \"here\"?");
        dialogueQueue.Enqueue("Excellent question! Welcome to the Underworld! Some might call it Hell, the Netherworld, the Land Down Under--wait no, that’s Australia. In any case...");
        dialogueQueue.Enqueue("You mortals have a lot of names for this place, pick your favorite.");
        dialogueQueue.Enqueue("What do you mean I’m in Hell...wait, I’m not dead right? You just said I’m not supposed to be here.");
        dialogueQueue.Enqueue("And that is the million dollar question! How did you get here? Well, in any case, the only way you can leave now is by asking Charon.");
        dialogueQueue.Enqueue("...who?");
        dialogueQueue.Enqueue("By Zeus, what do they teach mortals in school these days? Charon, ferryman of the Underworld? Does that ring a bell?");
        dialogueQueue.Enqueue("Uhhhh...");
        dialogueQueue.Enqueue("In any case, his job is to ferry souls from the Land of the Living to the Underworld, <b>not<b> the other way around.");
        dialogueQueue.Enqueue("Can't he make an exception? You said so yourself, I'm not even supposed to be here.");
        dialogueQueue.Enqueue("Hah, good luck getting him to help you with that reason. The only language he speaks is gold. Greedy son of a-- goddess named Nyx.");
        dialogueQueue.Enqueue("You check your pockets (unless you're wearing female clothing and therefore, the pockets are fake) for any spare change. There is none.");
        dialogueQueue.Enqueue("No money, eh? Well lucky for you, I happened to stumble on something good. Follow me.");        
        dialogueQueue.Enqueue("With your only way out of this place walking away, you have no choice but to follow him.");
    }
    private void Awake()
    {
        _textBox = GetComponent<TMP_Text>();

        _simpleDelay = new WaitForSeconds(1/charactersPerSecond);
        _interpunctuationDelay = new WaitForSeconds(interpunctuationDelay);

        _skipDelay = new WaitForSeconds(1/(charactersPerSecond * skipSpeedup));
        _textboxFullEventDelay = new WaitForSeconds(sendDoneDelay);
    }

    private void OnEnable()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(PrepareForNewText);
        }

        private void OnDisable()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(PrepareForNewText);
        }

    // Update is called once per frame
    void Update()
    {
        if (dialogueQueue.Count > 0 && Input.GetMouseButtonDown(0) && _readyForNewText)
            {
                string line = dialogueQueue.Dequeue();
                PrepareForNewText(_textBox);
                _textBox.text = line;
                if (line.Contains("Where the hell are you?"))
                {
                    blackBackground.SetActive(false);
                    sunGlow.SetActive(true);
                }
                if (line.Contains("Hello"))
                {
                    reaperImage.SetActive(true);
                }
                
                if ((dialogueQueue.Count < 16 && dialogueQueue.Count%2 == 0 && dialogueQueue.Count > 11) || (dialogueQueue.Count < 12 && dialogueQueue.Count%2 != 0))
                {
                    reaperName.text = "Reaper";
                }
                else if (dialogueQueue.Count > 3 && ((dialogueQueue.Count < 16 && dialogueQueue.Count%2 != 0 && dialogueQueue.Count > 12) || (dialogueQueue.Count < 11 && dialogueQueue.Count%2 == 0)))
                {
                    reaperName.text = "You";
                }
                else if (dialogueQueue.Count == 16)
                {
                    reaperName.text = "???";
                }
                else {
                    reaperName.text = null;
                }
            }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed right click " + _textBox.maxVisibleCharacters + " " + _textBox.textInfo.characterCount);
            if (_textBox.maxVisibleCharacters != _textBox.textInfo.characterCount - 1)
                Skip();
        }

        if (dialogueQueue.Count == 0)
        {
            StartCoroutine(FadeOut(reaperImage.GetComponent<Image>()));
        }
    }

    public void PrepareForNewText (Object obj)
    {
        if (obj != _textBox) //allow for objects/text outsde of textbox to not be affected
        return;

        if (!_readyForNewText)
            return;
        
        _readyForNewText = false;
        
        if (_typewriterCoroutine != null)
            StopCoroutine(_typewriterCoroutine);
        
        _textBox.maxVisibleCharacters = 0;
        _currentVisibleCharacterIndex = 0;

        _typewriterCoroutine = StartCoroutine(Typewriter());
    }

    private IEnumerator Typewriter()
    {
        TMP_TextInfo textInfo = _textBox.textInfo;
        
        while (_currentVisibleCharacterIndex < textInfo.characterCount + 1)
        {
            var lastCharacterIndex = textInfo.characterCount - 1;

            if (_currentVisibleCharacterIndex == lastCharacterIndex)
            {
                _textBox.maxVisibleCharacters++;
                yield return _textboxFullEventDelay;
                CompleteTextRevealed?.Invoke();
                _readyForNewText = true;
                yield break;
            }

            char character = textInfo.characterInfo[_currentVisibleCharacterIndex].character;

            _textBox.maxVisibleCharacters++;

            if (!CurrentlySkipping &&
                (character == '?' || character == '.' || character == ',' || character == ':' || 
                character == ';' || character == '!' || character == '-'))
            {
                yield return _interpunctuationDelay;
            }
            else
            {
                yield return CurrentlySkipping ? _simpleDelay: _simpleDelay;
            }

            CharacterRevealed?.Invoke(character);
            _currentVisibleCharacterIndex++;
        }
    }
    private void Skip(bool quickSkipNeeded = false)
    {
        if (CurrentlySkipping)
            return;
        
        CurrentlySkipping = true;

        if (!quickSkip || !quickSkipNeeded)
        {
            StartCoroutine(SkipSpeedupReset());
            return;
        }

        StopCoroutine(_typewriterCoroutine);
        _textBox.maxVisibleCharacters = _textBox.textInfo.characterCount;
        _readyForNewText = true;     
        CompleteTextRevealed?.Invoke();
    }

    private IEnumerator SkipSpeedupReset()
    {
        yield return new WaitUntil(() => _textBox.maxVisibleCharacters == _textBox.textInfo.characterCount - 1);
        CurrentlySkipping = false;
    }

    private YieldInstruction fadeInstruction = new YieldInstruction();
    IEnumerator FadeOut(Image image)
    {
        buttonText.text = "Continue";
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < 2f)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime ;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / 2f);
            image.color = c;
        }
    }
}
