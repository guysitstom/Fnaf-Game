using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Zombie_1_Movement : MonoBehaviour
{
    public bool Open;
    [SerializeField] GameObject[] ZombiePos;
    int currentZom;
    [SerializeField] float MinTime, MaxTime;
    [SerializeField] int DoorNum;
    [SerializeField] float KillTime;
    [SerializeField] GameObject DeathOverlay;
    public CameraSystem cams;
    [SerializeField] AudioSource knock;
    [SerializeField] GameObject[] Cam_blur;
    // Start is called before the first frame update
    void Start()
    {
        ZombiePos[0].SetActive(true);
        currentZom= 0;
        StartCoroutine(Waiting());
    }
    IEnumerator Waiting()
    {
        if (DoorNum != currentZom)
        {
            yield return new WaitForSecondsRealtime(Random.Range(MinTime, MaxTime));
            ZombiePos[currentZom].SetActive(false);
            ZombiePos[currentZom + 1].SetActive(true);
            currentZom++;
            StartCoroutine(Blur(currentZom));
            StartCoroutine(Waiting());
        }
        else
        {
            yield return new WaitForSecondsRealtime(7);
            if (Open)
            {
                ZombiePos[currentZom].SetActive(false);
                ZombiePos[currentZom + 1].SetActive(true);
                if (cams.LastActiveCam != cams.Cameras[7])
                {
                    cams.MainCam();
                }
                StartCoroutine(Death());
            }
            else
            {
                ZombiePos[currentZom].SetActive(false);
                ZombiePos[0].SetActive(true);
                currentZom = 0;
                knock.Play();
                StartCoroutine(Waiting());
            }
        }
        
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(KillTime);
        DeathOverlay.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        SceneManager.LoadScene("Death Scene");
    }
    IEnumerator Blur(int cam)
    {
        Cam_blur[cam].SetActive(true);
        Cam_blur[cam-1].SetActive(true);
        yield return new WaitForSeconds(1f);
        Cam_blur[cam].SetActive(false);
        Cam_blur[cam - 1].SetActive(false);
    }
}
