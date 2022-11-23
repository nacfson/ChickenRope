using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExampleWindow : EditorWindow
{
    Color color;
    ExamplePopup examplePopup = new ExamplePopup();
    [MenuItem("Window/Colorizer")]

    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Coloize");
    }
    private void OnGUI()
    {
        GUILayout.Label("coloring obj!!", EditorStyles.boldLabel);
        color = EditorGUILayout.ColorField("Color", color);
        if (GUILayout.Button("pres"))
        {
            Colorize();
        }
        if(GUILayout.Button("Popup ¶ç¿ì±â",GUILayout.Width(200)))
        {
            var activeRect = GUILayoutUtility.GetLastRect();
            PopupWindow.Show(activeRect,examplePopup);
        }
    }
    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}
public class ExamplePopup : PopupWindowContent
{
    public override void OnGUI(Rect rect)
    {
        EditorGUILayout.LabelField("ÆË¾÷");
    }
    public override void OnOpen()
    {
        Debug.Log("ÆË¾÷¿­¸²");
    }
    public override void OnClose()
    {
        Debug.Log("ÆË¾÷´ÝÈû");
    }

    public override Vector2 GetWindowSize()
    {
        return new Vector2(500, 500);
    }
}