using UnityEngine;

namespace QRPG.AutoMaticScripts
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
        [HideInInspector]
        public string[] components;
    }
    
}

