using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnTriggerEnter(Collider obj) // ��� ��������� ����������
    {
        if (obj.transform.tag == "Enemy")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}
