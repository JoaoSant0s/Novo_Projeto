using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class LevelEditor : EditorWindow 
{
    Texture2D map;
    GameObject baseBuildingPrefab;
    int offsetHeight;
    int offsetWidth;

    static Transform plataformContent;

    //[MenuItem("Tools/LevelEditor")]
    public static void ShowWindow() 
    {
        GetWindow<LevelEditor>("Level Editor");
        plataformContent = GameObject.FindGameObjectWithTag("Plataform_Content").transform;
    }

    void OnGUI() 
    {
        GUILayout.Label("Select your map texture level", EditorStyles.boldLabel);

        map = (Texture2D) EditorGUILayout.ObjectField("Level Texture", map, typeof(Texture2D), false);
        baseBuildingPrefab = (GameObject) EditorGUILayout.ObjectField("Building prefab", baseBuildingPrefab, typeof(GameObject), false);

        offsetHeight = EditorGUILayout.IntField("Offset Height", offsetHeight);
        offsetWidth = EditorGUILayout.IntField("Offset Width", offsetWidth);

        if (GUILayout.Button("Create Level"))
        {
            if(map == null)
            {
                Debug.Log("Set map");
                return;                
            }         

            var children = new List<GameObject>();
            foreach (Transform child in plataformContent) children.Add(child.gameObject);
            children.ForEach(child => DestroyImmediate(child));
            
            for (int i = 0; i < map.width; i++)
            {
                for (int j = 0; j < map.height; j++)
                {					
                    GenerateTile(i, j);
                }
            }            
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0) return;
        
        if(pixelColor == Color.black)
        {
            Vector3 position = new Vector3(x * offsetWidth, y + offsetHeight, 0);
            Instantiate(baseBuildingPrefab, position, Quaternion.identity, plataformContent);
        }

    }
}