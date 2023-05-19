﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConteroller : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal,0,moveVertical);

        rb.AddForce(movement*speed);
    }
}
