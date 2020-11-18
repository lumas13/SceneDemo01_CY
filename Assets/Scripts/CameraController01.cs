﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController01 : MonoBehaviour
{
    public GameObject playerGO;
    Vector3 posOffset = new Vector3 (0, 4f, -4f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerGO.transform.position + posOffset, 0.1f);
    }
}
