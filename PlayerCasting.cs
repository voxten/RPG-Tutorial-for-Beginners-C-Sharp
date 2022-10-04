using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour 
{
    public static float distanceFromTarget;
    private float _toTarget;

    private void FixedUpdate() 
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit)) 
        {
            _toTarget = Hit.distance;
            distanceFromTarget = _toTarget;
        }
    }
}
