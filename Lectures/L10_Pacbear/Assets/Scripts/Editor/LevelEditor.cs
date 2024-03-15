using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;

public class LevelEditor : EditorWindow
{
    bool mouseDown;

    float gridSize = 20f;

    float leftPadding = 10;
    float gridPadding = 2;

    int currentOption = 1;

    Color[] options =
    {
            Color.black,
            Color.white,
            Color.yellow,
            Color.green,
            Color.blue,
            Color.cyan,
        };

    string[] names =
    {
        "Pill",
        "Wall",
        "PacBear",
        "Pill",
        "Ghost",
        "Spawn"
    };

    private LevelData myData;
    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/Level Editor")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(LevelEditor));
    }

    private void OnGUI()
    {
        GUILayout.Label("Pacbear Level Editor", EditorStyles.boldLabel);
        if(myData == null)
        {
            if (File.Exists("Assets/Level.txt"))
            {
                string myDataString = File.ReadAllText("Assets/Level.txt");
                myData = JsonConvert.DeserializeObject<LevelData>(myDataString);
            } 
            else
                myData = new LevelData();
        }

        myData.levelWidth = EditorGUILayout.IntField(myData.levelWidth);
        myData.levelHeight = EditorGUILayout.IntField(myData.levelHeight);
        if (GUILayout.Button("Reset"))
        {
            if (EditorUtility.DisplayDialog("Reset", "Warning. This will clear your level. Are you sure?", "Yes", "...no"))
            {
                myData.grid = new int[myData.levelWidth, myData.levelHeight];
            }
        }
        Event e = Event.current;
        if(e.type == EventType.MouseDown && e.button == 0) //if we have an event with our left mouse button down
        {
            mouseDown = true;
        }
        else if (e.type == EventType.MouseUp && e.button == 0)
        {
            mouseDown = false;
        }
        for (int i = 0; i < options.Length; i++)
        {
            Rect r = new Rect(leftPadding + i * (gridSize + gridPadding), 140, gridSize, gridSize);

            if (r.Contains(e.mousePosition))
            {
                GUILayout.Label(names[i]);

                if (e.type == EventType.MouseDown && e.button == 0)
                {
                    currentOption = i;
                }

                if (currentOption == i)
                {
                    EditorGUI.DrawRect(new Rect(r.x - 1, r.y - 1, r.width + 2, r.height + 2), Color.red);
                }
            }
            EditorGUI.DrawRect(r, options[i]);
        }
        for(int i = 0; i < myData.grid.GetLength(0); i++)
        {
            for (int j = 0; j < myData.grid.GetLength(1); j++)
            {
                Rect r = new Rect(leftPadding + i * (gridSize + gridPadding), 180 + (myData.grid.GetLength(1) - j) * (gridSize + gridPadding), gridSize, gridSize);
                if (mouseDown && r.Contains(e.mousePosition))
                {
                    myData.grid[i, j] = currentOption;
                }
                int objectType = myData.grid[i, j];
                EditorGUI.DrawRect(r, options[objectType]);
            }
        }
        if (GUILayout.Button("Save"))
        {
            string myDataString = JsonConvert.SerializeObject(myData);
            File.WriteAllText("Assets/Level.txt", myDataString);
        }


    }
    // Update is called once per frame
    void Update()
    {
        this.Repaint();
    }
}
