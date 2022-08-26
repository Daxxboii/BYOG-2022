using UnityEditor;

namespace TheVegetationEngine
{
    [InitializeOnLoad]
    public class TVEHubAutorun
    {
        static TVEHubAutorun()
        {
            EditorApplication.update += OnInit;
        }

        static void OnInit()
        {
            EditorApplication.update -= OnInit;
            TVEHub window = EditorWindow.GetWindow<TVEHub>(false, "The Vegetation Engine", true);
            window.Show();
        }
    }
}

