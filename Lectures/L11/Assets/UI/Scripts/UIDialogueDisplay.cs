using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIDialogueDisplay : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent displayComplete;
    [HideInInspector]
    public UnityEvent loaded;
    private VisualElement _root, _characterDisplay, _dialogueContainer;
    private Button _dialogueButton;
    private TextElement _characterName;
    private TextElement _dialogueText;
    
    #region display settings for text

    [SerializeField] private float letterWaitTime = .2f;
    private string _finishedText;
    #endregion
    public void Load(DialogueText dialogueText)
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _dialogueContainer = _root.Q<VisualElement>("dialogueContainer");
        _characterDisplay = _root.Q<VisualElement>(UIConstants.characterDisplayName);
        _characterName = _root.Q<TextElement>(UIConstants.characterNameName);
        _dialogueText = _root.Q<TextElement>(UIConstants.dialogueTextName);
        string charRef = dialogueText.character_ref;
        DialogueCharacter currentCharacter =
            DialogueManager.Instance.GetCharacter(charRef);
        _characterName.text = currentCharacter.name;
        _finishedText = dialogueText.text;
        _dialogueText.text = "";
        _dialogueButton = _root.Q<Button>(UIConstants.dialogueButton);
        _dialogueButton.clicked += () =>
        {
            displayComplete.Invoke();
            _dialogueContainer.AddToClassList(UIConstants.flyOutRight);
        };
        Sprite sprite = currentCharacter.emotionDictionary[dialogueText.emotion];
        _characterDisplay.style.backgroundImage = new StyleBackground(sprite);

        Invoke("LazyWaitFunction", .1f);

        StartCoroutine((DisplayCharacters()));
    }
    void LazyWaitFunction()
    {
        _dialogueContainer.RemoveFromClassList(UIConstants.flyOutLeft);
    }
    IEnumerator DisplayCharacters()
    {
        yield return new WaitForSeconds(3);
        string currentString = "";
        for (int i = 0; i < _finishedText.Length; i++)
        {
            currentString += _finishedText[i];
            _dialogueText.text = currentString;
            yield return new WaitForSeconds(letterWaitTime);
        }
        _dialogueButton.RemoveFromClassList(UIConstants.hideElement);
        _dialogueButton.AddToClassList((UIConstants.showElement));
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
