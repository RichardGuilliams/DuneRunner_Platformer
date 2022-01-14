using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ComponentHolder : EditorWindow
{

    public GameObject gameObj;
    public Component component;
    public ScriptableObject scriptableObject;


    [MenuItem("Tools/Component Holder")]
    
    public static void ShowWindow()
    {
        GetWindow(typeof(ComponentHolder));
    }
}
