using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif

namespace PixelCrushers.LoveHate
{

    /// <summary>
    /// This scriptable object asset defines an emotion model, which is an EmotionDefinition list.
    /// It serves as the template for faction members' EmotionalState components.
    /// </summary>
    public class EmotionModel : ScriptableObject
    {

        public EmotionDefinition[] emotionDefinitions;

#if UNITY_EDITOR
        [MenuItem("Assets/Create/Love\u2215Hate/Emotion Model", false, 2)]
        public static void CreateEmotionModel()
        {
            var asset = ScriptableObject.CreateInstance<EmotionModel>() as EmotionModel;
            //asset.Initialize();
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (string.IsNullOrEmpty(path))
            {
                path = "Assets";
            }
            else if (!string.IsNullOrEmpty(Path.GetExtension(path)))
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New Emotion Model.asset");
            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
#endif

    }

}
