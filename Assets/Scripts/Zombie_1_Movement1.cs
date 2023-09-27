using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_1_Movement1 : MonoBehaviour
{
    public bool Open;
    [SerializeField] GameObject[] ZombiePos;
    int currentZom;
    [SerializeField] float MinTime, MaxTime;
    [SerializeField] int DoorNum;
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
            StartCoroutine(Waiting());
        }
        else
        {
            yield return new WaitForSecondsRealtime(7);
            if (Open)
            {
                ZombiePos[currentZom].SetActive(false);
                ZombiePos[currentZom + 1].SetActive(true);
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
