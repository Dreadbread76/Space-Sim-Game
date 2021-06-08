using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Spacegame.Ship.Player
{
    public class ShipInput : MonoBehaviour
    {
        [Range(-1, 1)]
        public float pitch;
        [Range(-1, 1)]
        public float yaw;
        [Range(-1, 1)]
        public float roll;
        [Range(-1, 1)]
        public float strafe;
        [Range(0, 1)]
        public float throttle;

        [Range(0, 1)]
        public float sensitivityMulti;
        [SerializeField]
        private float throttleSpeed = 0f;
        [SerializeField]
        private float rollSpeed = 5f;

        [SerializeField]
        public TMP_Text throttleText;

        private void Update()
        {
            SetStickCommandUsingMouse();

            UpdateKeyboardThrottle(KeyCode.W, KeyCode.S);
            UpdateMouseWheelThrottle();


            if (Input.GetMouseButton(0))
            {
                Fire();
            }
      

        
        
        }
        private void SetStickCommandUsingMouse()
        {
            Vector3 mousePos = Input.mousePosition;

            pitch = (mousePos.y - (Screen.height * 0.5f)) / (Screen.height) * 0.25f *sensitivityMulti;
            yaw = (mousePos.x - (Screen.width * 0.5f)) / (Screen.width) * 0.25f * sensitivityMulti;

            pitch = Mathf.Clamp(pitch, -1.0f, 1f);
            yaw = Mathf.Clamp(yaw, -1.0f, 1f);
        }
        public void UpdateKeyboardThrottle(KeyCode increaseKey, KeyCode decreaseKey)
        {
            float target = throttle;
            if (Input.GetKey(increaseKey))
            {
                target = 1;
            }
            else if (Input.GetKey(decreaseKey))
            {
                target = 0;
            }
            throttle = Mathf.MoveTowards(throttle, target, Time.deltaTime * throttleSpeed);
        }
  
        private void UpdateMouseWheelThrottle()
        {
            throttle += Input.GetAxis("Mouse ScrollWheel");
            throttle = Mathf.Clamp01(throttle);
            throttleText.text = "Throttle: " + Mathf.Round(throttle * 100f).ToString("000") + "%";
        }

        private void Fire()
        {
            
        }
     

    }
}