using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            BTree t = new BTree(4); // A B-Tree with minimum degree 4

            t.Insert(70);
            t.Insert(50);
            t.Insert(30);
            t.Insert(40);
            t.Insert(20);
            t.Insert(80);
            t.Insert(25);
            t.Insert(90);
            t.Insert(75);
            t.Insert(10);
            t.Insert(15);

            Debug.Log("The traversal of the constructed tree is:");
            t.Traverse();
        }
    }
}
