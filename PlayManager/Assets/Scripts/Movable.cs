using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {

    Dictionary<int, Vector3> positions = new Dictionary<int, Vector3>();
    public bool isSelected = false;
    private Vector3 vec;

    public void SetPosition(int time)
    {
        transform.position = positions[time];
    }

    void Update()
    {
        if (isSelected)
        {
            vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0;
            transform.position = vec;
        }
        Debug.Log(vec);
    }
}