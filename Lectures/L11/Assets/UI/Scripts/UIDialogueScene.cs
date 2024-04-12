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
    private DialogueScene _currentScene;
    private DialogueText[] _dialogueTexts;

    private int _currentDialogueText = 0;
    
    private void Start()
    {
        Invoke("Load", 3);
    }

    private void Load()
    {
        _currentScene = GameManager.Instance.GameData.scenes[0];
        _root = GetComponent<UIDocument>().rootVisualElement;
        _dialogueTexts = _currentScene.dialogue;
        LoadNextScene();

    }

    private void LoadNextScene()
    {
        GameObject dialogueDisplay = Instantiate(dialogueDisplayPrefab);
        UIDialogueDisplay dialogDisplay = dialogueDisplay.GetComponent<UIDialogueDisplay>();
        dialogDisplay.Load(_currentScene.dialogue[_currentDialogueText]);
        _root.Add(dialogueDisplay.GetComponent<UIDocument>().rootVisualElement);
        dialogDisplay.displayComplete.AddListener(() =>
        {
            //_root.Remove(dialogueDisplay.GetComponent<UIDocument>().rootVisualElement);
            Destroy(dialogDisplay, 3f);
            _currentDialogueText++;
            if(_currentDialogueText < _dialogueTexts.Length)
                LoadNextScene();
            //otherwise transition to the next scene
        });
    }
}
