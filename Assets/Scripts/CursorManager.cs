using UnityEngine;

namespace CustomCursor
{
    public class CursorManager : MonoBehaviour
    {
        public static CursorManager Instance { get; private set; }

        [SerializeField] private Texture2D cursorTextureDefault;
        [SerializeField] private Texture2D cursorTextureOther;

        [SerializeField] private Vector2 clickPosition = Vector2.zero;
        [SerializeField] private Vector2 clickPositionOther = new(0.5f, 0.5f);

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.Auto);
        }

        public void SetToMode(ModeOfCursor modeOfCursor)
        {
            switch (modeOfCursor)
            {
                case ModeOfCursor.Default:
                    Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.Auto);
                    break;
                case ModeOfCursor.Other:
                    Cursor.SetCursor(cursorTextureOther, clickPositionOther, CursorMode.Auto);
                    break;
            }
        }

        public enum ModeOfCursor
        {
            Default,
            Other
        }
    }
}
