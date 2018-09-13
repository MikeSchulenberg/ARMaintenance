using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    public Vector3 calRotation(int a, int b, int c)
    {
        var deltaTime = Time.deltaTime;
        var x = a * deltaTime;
        var y = b * deltaTime;
        var z = c * deltaTime;
        return new Vector3(x, y, z);
    }
}
