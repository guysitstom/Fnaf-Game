using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    private int CurrentHour;
    [SerializeField] private GameObject[] DisableObjects;
    [SerializeField] private GameObject[] EnableObjects;
    public TMP_Text textMeshPro;
    void Start()
    {
        CurrentHour = 0;
        StartCoroutine(Hour());
    }

    IEnumerator Hour()
    {
        if (CurrentHour == 6)
        {
            Victory();
            
        }
        yield return new WaitForSecondsRealtime(45);
        CurrentHour++;
        textMeshPro.text = CurrentHour + " AM";
        StartCoroutine(Hour());
    }
    
    public void Victory()
    {
        SceneManager.LoadScene("Victory");
        Debug.Log("6 am");
    }
}
