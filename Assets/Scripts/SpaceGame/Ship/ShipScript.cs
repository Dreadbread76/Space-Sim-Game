using System;
using System.Collections;
using System.Collections.Generic;
using Spacegame.Ship.Player;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ShipPhysics))]
[RequireComponent(typeof(ShipInput))]
public class ShipScript : MonoBehaviour
{
    private ShipInput input;
    private ShipPhysics physics;

    [SerializeField]
    private Animator anim;
    private int currentHealth;
    private int maxHealth = 100;
    
   
    [SerializeField]
    private TMP_Text healthText;
    [SerializeField]
    private TMP_Text shieldText;
    [SerializeField]
    private TMP_Text collisionText;
    [SerializeField]
    private TMP_Text deployText;
    [SerializeField]
    private float collisionDist;
   


    private void Awake()
    {
        input = GetComponent<ShipInput>();
        physics = GetComponent<ShipPhysics>();

        currentHealth = maxHealth;

        if(input == null || physics == null)
        {
            Debug.Log(name + ": is missing ShipInput OR ShipPhysics");
        }
    }

    private void Start()
    {
        collisionText.gameObject.SetActive(false);
        deployText.gameObject.SetActive(false);
    }

    private void Update()
    {
        physics.SetPhysicsInput(new Vector3(0, 0, -input.throttle), new Vector3(input.pitch,input.yaw , 0));

        RaycastHit hit;

        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.back),
            out hit, collisionDist))
        {
            
                Collider collider = hit.transform.gameObject.GetComponent<Collider>();
            
            if(collider != null && collisionText != null)
            {
                Debug.Log(collider.gameObject.name);
                collisionText.gameObject.SetActive(true);
            }
            else if(hit.transform.gameObject == null)
            {
                Debug.Log("No Collision");
                collisionText.gameObject.SetActive(false);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Hit();
        }
    }

   
    private void Hit()
    {
        anim.Play("Shield Flare");
       
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            deployText.gameObject.SetActive(true);
        }
        else
        {
            deployText.gameObject.SetActive(false);
        }
    }
    
}
