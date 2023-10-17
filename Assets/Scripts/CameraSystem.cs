using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] public GameObject[] Cameras;
    [SerializeField] public GameObject LastActiveCam;
    public GameObject Button;
    public GameObject Blur;
    [SerializeField] private GameObject LastActiveCamOverlay;
    [SerializeField] private GameObject[] CamOverlay;

    public void ChangeCam(int camNuber)
    {
        if (Cameras[camNuber] == LastActiveCam)
        {

        }
        else 
        {
            if (camNuber == 7)
            {

            }
            else
            {
                StartCoroutine(TurnOff());
            }
            Cameras[camNuber].SetActive(true);
            CamOverlay[camNuber].SetActive(true);
            LastActiveCam.SetActive(false);
            LastActiveCamOverlay.SetActive(false);
            LastActiveCamOverlay = CamOverlay[camNuber];
            LastActiveCam = Cameras[camNuber];
        }
    }

    public void Cam1(int cam)
    {
        Button.SetActive(true);
        ChangeCam(cam);
    }
    public void MainCam()
    {
        Button.SetActive(false);
        ChangeCam(7);
    }
    IEnumerator TurnOff()
    {
        Blur.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Blur.SetActive(false);
    }

}
