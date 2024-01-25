using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemHide
{
    public List<GameObject> hideobject;
    public AudioClip audioClip;
    public bool status = false;
    public string name;
}

public class GameManagerSteps : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioSource;
    private int currentIndex = -1;
    [SerializeField] private List<ItemHide> itemsList;


    void Start()
    {
        foreach (ItemHide item in itemsList)
        {
            foreach (GameObject child in item.hideobject)
            {
                child.SetActive(false);
            }
        }
        ShowMeSocketZone();

    }

    void Update()
    {
        if (itemsList.FindIndex(b => b.status == false) > currentIndex) {
            currentIndex++;
            ShowMeSocketZone();
        }
    }

    IEnumerator playEngineSound(AudioClip oldAudio = null, AudioClip newAudio = null)
    {
        if (oldAudio != null) {
            audioSource.clip = oldAudio;
            audioSource.Play();
            Debug.Log($"with audio first {currentIndex}");
            yield return new WaitForSeconds(oldAudio.length);
        } else
        {
            Debug.Log($"without audio first {currentIndex}");
            yield return new WaitForSeconds(3f);
        }
        if (newAudio != null)
        {
            /*Debug.Log($"with audio second {currentIndex}");
            yield return new WaitForSeconds(newAudio.length);*/
            audioSource.clip = newAudio;
            audioSource.Play();
        }
        else
        {
            Debug.Log($"without audio second {currentIndex}");
            yield return new WaitForSeconds(3f);
        }
    }

    public void ShowMeSocketZone()
    {
        
        if (currentIndex >= 0)
        {
            if (itemsList[currentIndex].hideobject.Count > 0)
            {
                foreach (GameObject child in itemsList[currentIndex].hideobject)
                {
                    if (child != null)
                    {
                        child.SetActive(false);
                    }
                }
            }
        }

        if (currentIndex < itemsList.Count)
        {
            currentIndex++;
            
            StartCoroutine(playEngineSound(itemsList[currentIndex].audioClip, itemsList[currentIndex + 1].audioClip));
        }

        if (itemsList[currentIndex].hideobject.Count > 0)
        {
            foreach (GameObject child in itemsList[currentIndex].hideobject)
            {
                if (child != null)
                {
                    child.SetActive(true);
                }
            }
        }

    }
}