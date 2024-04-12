using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TitleScreen : MonoBehaviour
{
    private VisualElement titleText, parentElement, root;
    private Button startButton;
    [SerializeField]
    AudioSource backgroundMusic;
    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        titleText = root.Q<VisualElement>("TitleBox");
        startButton = root.Q<Button>("StartButton");
        Invoke("TextFlyIn", .2f);
        startButton.RegisterCallback<TransitionEndEvent>(evt =>
        {
            startButton.ToggleInClassList("fadeBackground");
            startButton.ToggleInClassList("brightenBackground");
        });
        root.schedule.Execute(() =>
        {
            backgroundMusic.Play();
            startButton.ToggleInClassList("fadeBackground");
            startButton.ToggleInClassList("brightenBackground");
        }).StartingIn(5000);
    }
    private void TextFlyIn()
    {
        titleText.RemoveFromClassList("flyIn");
        startButton.RemoveFromClassList("flyIn");
    }
}
