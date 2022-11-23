using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleCustomMenu : EditorWindow, IHasCustomMenu
{
    public void AddItemsToMenu(GenericMenu menu)
    {
        menu.AddItem(new GUIContent("�����1"), true, () =>
        {
            Debug.Log("sdf");
        });

        menu.AddItem(new GUIContent("����� �߱޹�"), false, () =>
        {
            Debug.Log("����Ƽ �߱�");
        });
    }

    [MenuItem("Window/Ŀ���� �޴� ������")]
    static void open()
    {
        var window = GetWindow<ExampleCustomMenu>();
        var icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Scripts/icon.png");
        window.titleContent = new GUIContent("������", icon);

    }

    [MenuItem("Window/zz/�׽��͵� ������")]
    static void NewNesstedOpationMenu()
    {
        Debug.Log("��ø");
    }

    [MenuItem("Window/zz/�׽��͵� ������2")]
    static void NewNesstedOpationMenu2()
    {
        Debug.Log("��ø2");
    }

    [MenuItem("alsco/new option %#q", false, 1)]
    static void NewHotKeyOptionMenu()
    {
        Debug.Log("����1");
    }

    [MenuItem("alsco/new option &m")]
    static void NewHotKeyOptionMenu2()
    {
        Debug.Log("����2");
    }

    [MenuItem("alsco/new option HOME")]
    static void NewHotKeyOptionMenu3()
    {
        Debug.Log("����");
    }

    [MenuItem("alsco/new option F3")]
    static void NewHotKeyOptionMenu4()
    {
        Debug.Log("����4");
    }

    [MenuItem("Assets/Add Configuration^^")]
    static void AddConfig()
    {

    }

    [MenuItem("CONTEXT/Rigidbody/�� �ɼ�")]
    static void AddContextRigidBodyMenu()
    {
        Debug.Log("new??");
    }

    [MenuItem("CONTEXT/Transform/�� �ɼ�")]
    static void AddContextTranformMenu()
    {
        Debug.Log("Ʈ��������??");
    }
}
