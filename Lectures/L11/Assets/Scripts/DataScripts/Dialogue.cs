﻿using System;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueData
{
    public DialogueCharacter[] characters;
    public DialogueScene[] scenes;
}

[System.Serializable]
public class DialogueCharacter
{
    public string reference;
    public string name;
    public DialogueEmotions emotions;
    public Dictionary<string, Sprite> emotionDictionary = new Dictionary<string, Sprite>();
}

[System.Serializable]
public class DialogueEmotions
{
    public string happy;
    public string sad;
    public string shocked;
    public string neutral;
    public string angry;
}

[System.Serializable]
public class DialogueScene
{
    public string name;
    public int order;
    public string background;
    public DialogueText[] dialogue;
}
[System.Serializable]
public class DialogueText
{
    public string character_ref;
    public string emotion;
    public string text;
}
