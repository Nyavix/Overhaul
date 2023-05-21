using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossShooting : MonoBehaviour
{

    public CinemachineVirtualCamera chcamera;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            boss.GetComponent<Boss>().isShooting = true;

            chcamera.m_Lens.OrthographicSize = 12;
        }
    }
}
