using System.Collections;
using System.Collections.Generic;
using Spacegame.Ship.Player;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ShipPhysics))]
[RequireComponent(typeof(ShipInput))]
public class Ship : MonoBehaviour
{
    private ShipInput input;
    private ShipPhysics physics;

    private int currentHealth;
    private int maxHealth = 100;
    

    private void Awake()
    {
        input = GetComponent<ShipInput>();
        physics = GetComponent<ShipPhysics>();

        if(input == null || physics == null)
        {
            Debug.Log(name + ": is missing ShipInput OR ShipPhysics");
        }
    }
    private void Update()
    {
        physics.SetPhysicsInput(new Vector3(0, 0, input.throttle), new Vector3(input.pitch,input.yaw , 0));
    }
    
}
