using UnityEngine;
using UnityEngine.EventSystems;
using static CustomCursor.CursorManager;

namespace CustomCursor
{
    public class ChangeCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private ModeOfCursor modeOfCursor;

        public void OnPointerEnter(PointerEventData eventData)
        {
            Instance.SetToMode(modeOfCursor);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Instance.SetToMode(ModeOfCursor.Default);
        }
    }
}
