using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] Cameras;
    [SerializeField] private GameObject LastActiveCam;

    public void ChangeCam(int camNuber)
    {
        
        Cameras[camNuber].SetActive(true);
        LastActiveCam.SetActive(false);
        LastActiveCam = Cameras[camNuber];
    }

    public void Cam1()
    {
        ChangeCam(0);
    }
    public void Cam2()
    {
        ChangeCam(1);
    }
    public void Cam3()
    {
        ChangeCam(2);
    }
    public void Cam4()
    {
        ChangeCam(3);
    }
    public void Cam5()
    {
        ChangeCam(4);
    }
    public void Cam6()
    {
        ChangeCam(5);
    }
    public void Cam7()
    {
        ChangeCam(6);
    }
    public void MainCam()
    {
        ChangeCam(7);
    }


}
