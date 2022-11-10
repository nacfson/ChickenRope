    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    [CustomEditor(typeof(ObjectBuilderScript))]
    public class ObjectBuildEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ObjectBuilderScript obs = (ObjectBuilderScript)target;  
            if(GUILayout.Button("Object Builder Button"))
            {
                obs.BuildObject();
            }
        }
    }
