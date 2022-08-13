/*
using UnityEngine;
using UnityEditor;

public class DashEditor : EditorWindow
{
    float zValue;
    int count = 5;
    GameObject parent;

    [MenuItem("Window/Dash")]
    public static void showWindow()
    {
        GetWindow<DashEditor>("DashEditor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create From Selected Objects", EditorStyles.boldLabel);
        GUILayout.Label("Z Value", EditorStyles.boldLabel);
        zValue = EditorGUILayout.FloatField(zValue);
        Debug.Log("zValue : " + zValue);
        GUILayout.Label("Count", EditorStyles.boldLabel);
        count = EditorGUILayout.IntField(count);
        Debug.Log("Count : " + count);
        parent = GameObject.FindGameObjectWithTag("Parent");

        if (GUILayout.Button("Create"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                for (int i = 0; i < count; i++)
                {
                    GameObject g = Instantiate(obj);
                    Vector3 pos = obj.transform.position;
                    pos.z += zValue * (i + 1);
                    g.transform.position = pos;
                    g.transform.SetParent(parent.transform);
                }

            }
        }
    }
}
*/
