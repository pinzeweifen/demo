using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QRPG.Frame
{
    [RequireComponent(typeof(Button))]
    public class QShowButton:MonoBehaviour
    {
        private Button m_Button;

        public QBaseWindow Window
        {
            set {
                if (m_Button == null)
                    m_Button = GetComponent<Button>();

                m_Button.onClick.AddListener(value.Show);
            }
        }
        
        private void OnDestroy()
        {
            m_Button.onClick.RemoveAllListeners();
            m_Button = null;
        }

    }
}
