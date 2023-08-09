using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Move Camera")]
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    [Header("Activate/Deactivate Room")]
    [SerializeField] private Transform activatePreviousRoom;
    [SerializeField] private Transform activateNextRoom;


    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
                activateNextRoom.GetComponent<Room>().ActivateRoom(true);
                activatePreviousRoom.GetComponent<Room>().ActivateRoom(false);
            }
            else
            {
                cam.MoveToNewRoom(previousRoom);
                activatePreviousRoom.GetComponent<Room>().ActivateRoom(true);
                activateNextRoom.GetComponent<Room>().ActivateRoom(false);
            }

        }
    }
}
