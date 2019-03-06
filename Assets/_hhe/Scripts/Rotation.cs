using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
    public int RotationSpeed = 90; //degrees per second = 4 seconds for a revolution 
    private Transform _transform;
    void Start () {
        //cache the transform in our managed code side 
        _transform = transform;
    }

    void Update () {
        //Since deltaTime is the elapsed time since the last frame,  
        //let’s assume its one second. 1 * 90 = 90 degrees per second.  
        //Simple, right? Rotate’s parameters is (x,y,z, coordinate system) 
        _transform.Rotate(0, RotationSpeed * Time.deltaTime, 0, Space.World);
    }
}
