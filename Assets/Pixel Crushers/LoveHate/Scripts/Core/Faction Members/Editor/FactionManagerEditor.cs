using UnityEngine;  
using UnityEditor;  

namespace PixelCrushers.LoveHate
{

    /// <summary>
    /// This script reserves the possibility of a custom editor for FactionManager.
    /// It's simple enough right now that it doesn't merit a custom editor.
    /// </summary>
    //[CustomEditor(typeof(FactionManager))]
    //[CanEditMultipleObjects]
    //public class FactionManagerEditor : Editor
    public class FactionManagerEditor
    {

        /// <summary>
        /// Adds menu item GameObject > Love/Hate > Faction Manager.
        /// </summary>
        [MenuItem("GameObject/Love\u2215Hate/Faction Manager")]
        public static void CreateNewFactionManager()
        {
            new GameObject("Faction Manager", typeof(FactionManager));
        }

	}

}
