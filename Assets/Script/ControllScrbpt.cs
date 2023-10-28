using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllScrbpt : MonoBehaviour, IBeginDragHandler, IDragHandler {

    Rigidbody player;

    private GameObject ObjectHero;
    private Jump ScriptJump;
    private Move ScriptMove;

    public int speedX = 1;
    public int speedZ = 1;

    void Start()
    {
        ObjectHero = GameObject.FindGameObjectWithTag("Player");
        ScriptJump = ObjectHero.GetComponent<Jump>();
        ScriptMove = ObjectHero.GetComponent<Move>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > ((Mathf.Abs(eventData.delta.y))))
        {
            if (eventData.delta.x > 0)
            {
                ScriptMove.moveHorizontal = speedX;
            } else 
            {
                ScriptMove.moveHorizontal = -speedX;
            } 
        }
        else
        {
            if (eventData.delta.y > 0)
            {
                ScriptMove.moveVertical = speedZ;
            }
            else
            {
                ScriptMove.moveVertical = -speedZ;
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {        
    }
    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.touchCount > 0)
    //        //ScriptJump.JumpActive();       
    //}
}
