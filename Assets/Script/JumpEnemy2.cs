using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy2 : MonoBehaviour
{
    bool is_ground = false;
    Rigidbody enemy;
    public float force = 6;

    private const float CheckPeriod = 1.5f;
    private float m_LastCheck = CheckPeriod;

    public float speed = 6f;
    public float moveVertical = -1f;



    void Start()
    {
        enemy = GetComponent<Rigidbody>();

        //ObjectInspector = GameObject.FindGameObjectWithTag("Inspector");

        //string flag = "";
    }

    void OnTriggerStay(Collider col)
    {
        if (col == null) return;

        if (col.tag == "ground" || col.tag == "ground0") is_ground = true;

    }
    void OnTriggerExit(Collider col)
    {

        if (col == null) return;
        else if (col.tag == "ground" || col.tag == "ground0") is_ground = false;
        //else if (col.tag == "ground0" && col.name != flag)
        //{
        //    is_ground = false;
        //    //flag = col.name;
        //    //ObjectInspector.GetComponent<Inspector>().CreateSpan();

        //}
    }

    private void Update()
    {
        gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        m_LastCheck -= Time.deltaTime;
        if (m_LastCheck < 0)
        {
            if (is_ground)
            {
                enemy.AddForce(Vector3.up * force, ForceMode.Impulse);
                Vector3 movement = new Vector3(moveVertical, 0.0f, 0.0f);
                enemy.AddForce(movement * speed);
            }
            m_LastCheck = CheckPeriod;
        }

    }
}
