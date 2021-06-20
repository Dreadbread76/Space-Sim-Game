using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipPhysics : MonoBehaviour
{
    private Rigidbody rbody;

    public float forceMultiplier = 100f;

    public Vector3 linearForce = new Vector3(100, 100, 100);
    public Vector3 angularForce = new Vector3(100, 100, 100);

    private Vector3 appliedLinearForce = Vector3.zero;
    private Vector3 appliedAngularForce = Vector3.zero;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
        if(rbody == null)
        {
            rbody.AddRelativeForce(appliedLinearForce * forceMultiplier, ForceMode.Force);
            rbody.AddRelativeTorque(appliedAngularForce * forceMultiplier, ForceMode.Force);
        }
    }
    public void FixedUpdate()
    {
        if (rbody != null)
        {
            rbody.AddRelativeForce(appliedLinearForce * forceMultiplier, ForceMode.Force);
            rbody.AddRelativeTorque(appliedAngularForce * forceMultiplier, ForceMode.Force);
        }
    }

    /// <summary>
    /// Force input
    /// </summary>
    /// <param name="linearInput"> The linear Input of the physics</param>
    /// <param name="angularInput">The angular Input of the physics</param>
    public void SetPhysicsInput(Vector3 linearInput, Vector3 angularInput)
    {
        appliedLinearForce = MultiplyByComponent(linearInput, linearForce);
        appliedAngularForce = MultiplyByComponent(angularInput, angularForce);
    }
    /// <summary>
    /// The multiplication of the input and force of the physics
    /// </summary>
    /// <param name="a">the liniear and angular Input</param>
    /// <param name="b">the liniear and angular Force</param>
    /// <returns> The vector3 that the ship is travelling in </returns>
    private Vector3 MultiplyByComponent(Vector3 a, Vector3 b)
    {
        Vector3 ret;

        ret.x = a.x * b.x;
        ret.y = a.y * b.y;
        ret.z = a.z * b.z;

        return ret;
    }
}
