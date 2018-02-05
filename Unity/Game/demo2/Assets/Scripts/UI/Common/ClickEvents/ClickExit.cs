using UnityEngine;
using UnityEngine.EventSystems;

public class ClickExit : MonoBehaviour,IPointerClickHandler {

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
