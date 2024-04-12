using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TextAsset jsonFile;

    public DialogueData GameData { get; private set; }
    // Start is called before the first frame update
    protected override void Awake()
    {
        Instance.GameData = JsonUtility.FromJson<DialogueData>(jsonFile.text);
        DialogueManager.Instance.Initialize(Instance.GameData);
        Debug.Log(Instance.GameData);
    }
    
}
