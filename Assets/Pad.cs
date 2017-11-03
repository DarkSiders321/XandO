using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pad : MonoBehaviour, IPointerDownHandler {

    public int row, column;

    GameController c;

    void Start()
    {
        c = GameObject.Find("GameLogic").GetComponent<GameController>();
    }

    // Trigger all registered callbacks.
    public virtual void OnPointerDown(PointerEventData eventData){
   
        c.checkClickedPad(row, column);
    }
}
