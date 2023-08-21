using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorState : MonoBehaviour
{
    [SerializeField] public  bool DoorOpenLeft;

    [SerializeField] public  bool DoorOpenRight;

    [SerializeField] public  bool VentOpen;

    public void OpenDoorLeft()
    {
        DoorOpenLeft = true;
    }

    public void CloseDoorLeft()
    {
        DoorOpenLeft = false;
    }

    public void OpenDoorRight()
    {
        DoorOpenRight = true;
    }

    public void CloseDoorRight()
    {
        DoorOpenRight = false;
    }
    public void OpenVent()
    {
        VentOpen = true;
    }

    public void CloseVent()
    {
        VentOpen = false;
    }
}
