﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
