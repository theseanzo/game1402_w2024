using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    private Dictionary<string, DialogueCharacter> characters = new Dictionary<string, DialogueCharacter>();
    private Dictionary<string, DialogueScene> scenes = new Dictionary<string, DialogueScene>();
    
    public void Initialize(DialogueData data)
    {
        foreach (DialogueScene dialogueScene in data.scenes)
        {
            scenes.Add(dialogueScene.name, dialogueScene);
        }
        foreach (DialogueCharacter dialogueCharacter in data.characters)
        {
            characters.Add(dialogueCharacter.reference, dialogueCharacter);
            string path = "Characters/" + dialogueCharacter.reference;
            Sprite[] sprites = Resources.LoadAll<Sprite>(path);
            foreach (Sprite sprite in sprites)
            {
                if (sprite.name == dialogueCharacter.emotions.happy)
                {
                    dialogueCharacter.emotionDictionary.Add("happy", sprite);
                }
                else if (sprite.name == dialogueCharacter.emotions.sad)
                {
                    dialogueCharacter.emotionDictionary.Add("sad", sprite);
                }
                else if (sprite.name == dialogueCharacter.emotions.neutral)
                {
                    dialogueCharacter.emotionDictionary.Add("neutral", sprite);
                }
                else if (sprite.name == dialogueCharacter.emotions.shocked)
                {
                    dialogueCharacter.emotionDictionary.Add("shocked", sprite);
                }
                else if (sprite.name == dialogueCharacter.emotions.angry)
                {
                    dialogueCharacter.emotionDictionary.Add("angry", sprite);
                }
            }
        }
    }

    public DialogueCharacter GetCharacter(string characterRef)
    {
        return characters[characterRef];
    }

    public DialogueScene GetScene(string sceneRef)
    {
        return scenes[sceneRef];
    }

    public Sprite GetCharacterSprite(string characterRef, string emotion)
    {
        return GetCharacter(characterRef).emotionDictionary[emotion];
    }
}
