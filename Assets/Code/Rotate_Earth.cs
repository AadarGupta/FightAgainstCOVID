using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Earth : MonoBehaviour {

    public float rotateSpeed;

	void Update()
    {
        rotate();
    }

    void rotate()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }
}
