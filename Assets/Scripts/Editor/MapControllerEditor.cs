using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(MapController))]
    public class MapControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            MapController mapController = (MapController) target;

            base.OnInspectorGUI();
            if (GUILayout.Button("generate"))
            {
                mapController.Generate();
            }
        }
    }
}