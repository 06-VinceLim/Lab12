﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    float rotatespeed;
    // Start is called before the first frame update
    void Start()
    {
        rotatespeed = Random.Range(60.0f, 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * rotatespeed);
    }
}
