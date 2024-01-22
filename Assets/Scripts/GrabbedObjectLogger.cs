using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbedObjectLogger : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    [SerializeField] private Transform ParentObj;
    [SerializeField] private Transform child;

    [System.Obsolete]
    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable == null)
        {
            Debug.LogError("XRGrabInteractable component not found on " + gameObject.name);
            return;
        }

        grabInteractable.onSelectEntered.AddListener(OnGrab);

        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        child = FindChildByName(ParentObj, gameObject.name);

        if (child != null)
        {
            if (interactor.name == "Direct Interactor")
            {
                child.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }
            
            // gameObject.layer = LayerMask.NameToLayer("SnapZone");
            gameObject.GetComponent<XRGrabInteractable>().interactionLayers = LayerMask.NameToLayer("SnapZone");
            child.GetComponent<XRSocketInteractor>().interactionLayers = LayerMask.NameToLayer("SnapZone");
            // Perform any additional actions with the found child object
        }
        else
        {
            Debug.LogWarning("Child not found: " + gameObject.name);
        }
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        Debug.Log(interactor.name);
        child.GetComponent<MeshRenderer>().enabled = false;
    }

    private Transform FindChildByName(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child;
            }
        }

        return null;
    }
}
