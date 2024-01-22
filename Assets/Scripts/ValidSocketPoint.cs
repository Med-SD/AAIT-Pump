using UnityEngine;

public class ValidSocketPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ParentObj;
    [SerializeField] private GameObject ParentObjOut;
    private int currentIndex = -1;
    private GameObject oldObj;
    private GameObject currentObj;

    void Start()
    {
        foreach (Transform child in ParentObj.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in ParentObjOut.transform)
        {
            child.gameObject.GetComponent<Outline>().enabled = false;
        }
        ShowMeSocketZone();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMeSocketZone()
    {
        if (currentIndex >= 0)
        {
            ParentObj.transform.GetChild(currentIndex).GetComponent<MeshRenderer>().enabled = false;
            // oldObj.GetComponent<XRGrabInteractable>().interactionLayers = LayerMask.GetMask("SnapeZone");
        }
        
        if (currentIndex < ParentObj.transform.childCount)
        {
            currentIndex++;
        }
        
        if (!ParentObj.transform.GetChild(currentIndex).gameObject.activeSelf)
        {
            ParentObj.transform.GetChild(currentIndex).gameObject.SetActive(true);
            currentObj = ParentObjOut.transform.Find(ParentObj.transform.GetChild(currentIndex).gameObject.name).gameObject;
        }

        if (ParentObjOut.transform.GetChild(0).gameObject.GetComponent<Outline>().enabled == false)
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