using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QGUI
{
    public class QMarkupField:MonoBehaviour
    {
        public enum Jurisdiction
        {
            Public,
            Protected,
            Private
        }

        public Jurisdiction jurisdiction;
        public string component;

        [HideInInspector]
        public int index;
    }
    
}

