using UnityEngine;

namespace QRPG.Frame
{
    public abstract class QBaseWindow:MonoBehaviour
    {
        public Vector2 m_ShowPos;
        protected RectTransform m_UITr;

        protected abstract void Initialise();

        private void Awake()
        {
            m_UITr = (RectTransform)transform;
            Initialise();
            gameObject.SetActive(false);
        }

        public void Show()
        {
            m_UITr.anchoredPosition = m_ShowPos;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

    }
}
