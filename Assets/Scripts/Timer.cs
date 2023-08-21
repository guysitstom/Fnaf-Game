using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int CurrentHour;
    [SerializeField] private GameObject[] DisableObjects;
    [SerializeField] private GameObject[] EnableObjects;
    void Start()
    {
        CurrentHour = 0;
        StartCoroutine(Hour());
    }

    IEnumerator Hour()
    {
        yield return new WaitForSecondsRealtime(60);
        CurrentHour++;
        StartCoroutine(Hour());
    }
    private void Update()
    {
        if (CurrentHour == 6)
        {
            Victory();
        }
    }
    public void Victory()
    {
        Debug.Log("6 am");
    }
}
