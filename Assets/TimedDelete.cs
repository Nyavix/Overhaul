using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDelete : MonoBehaviour
{
    public float deleteTime = 8;

    void Start()
    {
        Destroy(this.gameObject, deleteTime);
    }
}
