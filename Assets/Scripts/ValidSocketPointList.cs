using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item{
	public GameObject socketPlace;
	public GameObject outGameobj;
    public AudioClip audioClip;
	public bool status = false;
	public string name;
}

public class ValidSocketPointList : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioSource;
    private int currentIndex = -1;
    private GameObject oldObj;
    private GameObject currentObj;
    [SerializeField] private List<Item> itemsList;


    void Start()
    {
        foreach (Item child in itemsList)
        {
            child.socketPlace.SetActive(false);
        }
        StartCoroutine(playEngineSound());
    }

    void OnPostRender()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator playEngineSound()
    {
        yield return new WaitForSeconds(5f);
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 1f);
        ShowMeSocketZone();
    }

    public void ShowMeSocketZone()
    {

        if (currentIndex >= 0)
        {
            itemsList[currentIndex].socketPlace.GetComponent<MeshRenderer>().enabled = false;
            // oldObj.GetComponent<XRGrabInteractable>().interactionLayers = LayerMask.GetMask("SnapeZone");
        }
        
        if (currentIndex < itemsList.Count)
        {
            currentIndex++;
            audioSource.clip = itemsList[currentIndex].audioClip;
            audioSource.Play();
        }
        
        if (!itemsList[currentIndex].socketPlace.activeSelf)
        {
            itemsList[currentIndex].socketPlace.gameObject.SetActive(true);
            currentObj = itemsList[currentIndex].outGameobj;
        }

        if (itemsList[currentIndex].outGameobj.GetComponent<Outline>().enabled == false)
        {
            if (currentIndex != 0)
            {
                oldObj.GetComponent<Outline>().enabled = false;
                
            }

            currentObj.GetComponent<Outline>().enabled = true;
            oldObj = currentObj;
        }

    }
}

// when i got i child and pout it in skoect zone the child get
// removed from init list so the error out of range
// is got fix it by fix index to zero
// how to add fire in unity
// 1. wood
// 2. liquid acid 
// 3. electric