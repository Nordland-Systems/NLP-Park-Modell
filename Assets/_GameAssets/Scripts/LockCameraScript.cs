using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCameraScript : MonoBehaviour
{

    [SerializeField] private bool isLocked;

    [SerializeField] private FirstPersonAIO fpsAIO;

    [SerializeField] private Texture2D customCursor;

    private void Start()
    {
        Cursor.SetCursor(customCursor, new Vector2(16f,16f), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isLocked = !isLocked;

            if (isLocked)
            {
                fpsAIO.ControllerPause();
                /*Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                fpsAIO.enableCameraMovement = true;
                fpsAIO.autoCrosshair = true;
                fpsAIO.lockAndHideCursor = true;*/
            }
            else
            {
                fpsAIO.ControllerPause();
                /*Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                fpsAIO.enableCameraMovement = false;
                fpsAIO.autoCrosshair = false;
                fpsAIO.lockAndHideCursor = false;*/
            }
        }
    }
}
