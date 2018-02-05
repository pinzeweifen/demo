using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

[RequireComponent(typeof(LatticeUI))]
public abstract class SwapArticle : MonoBehaviour,IPointerClickHandler {

    public LatticeUI obj;
    public static Action<bool> selectChanaged;
    private static LatticeUI selectObject;
    public static LatticeUI SelectObject{get { return selectObject; }}
    protected abstract bool IsSwap(LatticeUI select, LatticeUI current);

    public void DeSelectObject()
    {
        selectObject = null;
    }
    
    private void Awake()
    {
        obj = GetComponent<LatticeUI>();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (selectObject == null)
        {
            selectObject = obj;

            if (selectChanaged != null)
                selectChanaged(true);
        }
        else
        {
            if (IsSwap(selectObject, obj))
            {
                var tmp = obj.Value;
                obj.Value = selectObject.Value;
                selectObject.Value = tmp;
            }
            
            selectObject = null;

            if (selectChanaged != null)
                selectChanaged(false);
        }
    }
}
