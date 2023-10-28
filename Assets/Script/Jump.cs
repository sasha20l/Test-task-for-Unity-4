using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    bool is_ground = false;     
    Rigidbody player;         
    public float force = 6;

    private GameObject ObjectInspector;

    string flag;

    void Start()
    {
        player = GetComponent<Rigidbody>();

        ObjectInspector = GameObject.FindGameObjectWithTag("Inspector");

    }

    void OnTriggerStay(Collider col)
    {
        if (col == null) return;

        if (col.tag == "ground" || col.tag == "ground0") is_ground = true;
        
    }
    void OnTriggerExit(Collider col)
    {

        if (col == null) return;
        else if (col.tag == "ground") is_ground = false;
        else if (col.tag == "ground0" && col.name != flag)
        {
            is_ground = false;
            flag = col.name;
            ObjectInspector.GetComponent<Inspector>().CreateSpan();

        }
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && is_ground)
            player.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    //public void JumpActive()
    //{
    //    if (is_ground)
    //        player.AddForce(Vector3.up * force, ForceMode.Impulse);
    //}
}
