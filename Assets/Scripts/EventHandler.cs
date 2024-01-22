using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public UnityEvent onEnterEvent;
    public UnityEvent onExitEvent;
    private PointerEventData db;

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        db = pointerEventData;
        Debug.Log(pointerEventData.pointerCurrentRaycast.gameObject.name);
        //Output to console the GameObject's name and the following message
        if (pointerEventData.pointerCurrentRaycast.gameObject.name == "") {
            onEnterEvent.Invoke();
        }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        db = pointerEventData;
        //Output the following message with the GameObject's name
        onExitEvent.Invoke();
    }

    public void moveForward(GameObject obj) {
        db.pointerEnter.transform.position -= new Vector3(0, 0, 0.05f);
    }

    public void moveBack(GameObject obj)
    {
        db.pointerEnter.transform.position += new Vector3(0, 0, 0.05f);
    }

    public void TestingEvent()
    {
        Debug.Log("This event Work!");
    }
}