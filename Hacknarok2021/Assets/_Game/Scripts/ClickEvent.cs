using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class ClickEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _click;
    [SerializeField] private bool _sendFSMEvent = false;
    [SerializeField] private PlayMakerFSM _fsm = null;
    [SerializeField] private string _fsmEvent = "clicked";
    

    private void OnMouseDown()
    {
        Debug.Log("Click");
        
        _click?.Invoke();

        if (_sendFSMEvent)
        {
            if (_fsm != null)
            {
                _fsm.SendEvent(_fsmEvent);
            }
        }
    }
}
