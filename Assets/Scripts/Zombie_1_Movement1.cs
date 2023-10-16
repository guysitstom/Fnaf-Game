using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie_1_Movement1 : MonoBehaviour
{
    public bool Open;
    [SerializeField] GameObject[] ZombiePos;
    int currentZom;
    [SerializeField] float MinTime, MaxTime;
    [SerializeField] int DoorNum;
    [SerializeField] float KillTime;
    [SerializeField] GameObject DeathOverlay;
    // Start is called before the first frame update
    void Start()
    {
        ZombiePos[0].SetActive(true);
        currentZom= 0;
        StartCoroutine(Waiting());
    }
    IEnumerator Waiting()
    {
        if (currentZom == 4)
        {
            yield return new WaitForSecondsRealtime(4);
            ZombiePos[currentZom].SetActive(false);
            ZombiePos[currentZom + 1].SetActive(true);
            currentZom++;
            StartCoroutine(Waiting());
        }
        else
        {
            if (DoorNum != currentZom)
            {
                yield return new WaitForSecondsRealtime(Random.Range(MinTime, MaxTime));
                ZombiePos[currentZom].SetActive(false);
                ZombiePos[currentZom + 1].SetActive(true);
                currentZom++;
                StartCoroutine(Waiting());
            }
            else
            {
                yield return new WaitForSecondsRealtime(2);
                if (Open)
                {
                    ZombiePos[currentZom].SetActive(false);
                    ZombiePos[currentZom + 1].SetActive(true);
                    StartCoroutine(Death());
                }
                else
                {
                    ZombiePos[currentZom].SetActive(false);
                    ZombiePos[0].SetActive(true);
                    currentZom = 0;
                    StartCoroutine(Waiting());
                }
            }
        }
        
        
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(KillTime);
        DeathOverlay.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("Death Scene");
    }
}
