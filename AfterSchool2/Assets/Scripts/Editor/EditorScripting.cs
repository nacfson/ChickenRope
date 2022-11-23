using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorScripting : EditorWindow
{
    string testString = "First TextField";
    [MenuItem("Window/TestMenuItem")]
    public static void ShowWindow()
    {
        //GetWindow<>("ExampleWindow");
        EditorWindow.GetWindow(typeof(EditorScripting));
    }
    private void OnGUI()
    {
        GUILayout.Label("First Label",EditorStyles.boldLabel);
        testString = EditorGUILayout.TextField("TF_Name",testString);
        if(GUILayout.Button("press btn"))
        {
            Debug.Log("buttonn pressed!");
        }
    }
}