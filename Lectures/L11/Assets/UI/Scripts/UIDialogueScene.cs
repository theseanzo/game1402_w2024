using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
public class UIDialogueScene : MonoBehaviour
{
    [SerializeField]
    string characterDisplayName = "characterDisplay", characterNameName = "characterName", dialogueTextName="dialogueText";

    [SerializeField] private GameObject dialogueDisplayPrefab;
    private VisualElement _root, _characterDisplay;
    // private TextElement _characterName;
    // private TextElement _dialogueText;
    private DialogueScene _currentScene;
    private DialogueText[] _dialogueTexts;
    
    
    private void Start()
    {
        Invoke("Load", 5);
    }

    private void Load()
    {
        _currentScene = GameManager.Instance.GameData.scenes[0];
        _root = GetComponent<UIDocument>().rootVisualElement;
        
        GameObject dialogueDisplay = Instantiate(dialogueDisplayPrefab);
        dialogueDisplay.GetComponent<UIDialogueDisplay>().Load(_currentScene.dialogue[0]);
        _root.Add(dialogueDisplay.GetComponent<UIDocument>().rootVisualElement);
    }
}
