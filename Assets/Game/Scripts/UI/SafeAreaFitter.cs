using UnityEngine;

namespace CardSorting.UI
{
    /// <summary>
    /// To make sure we are in the safe area in the UI.
    /// Just put it in the parent object.
    /// SourceCode taken from: https://www.youtube.com/watch?v=cyDflP3RqT4
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaFitter : MonoBehaviour
    {
        void Awake()
        {
            RectTransform rectTransfrom = GetComponent<RectTransform>();
            Rect safeArea = Screen.safeArea;
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = anchorMin + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            rectTransfrom.anchorMin = anchorMin;
            rectTransfrom.anchorMax = anchorMax;
        }
    }
}