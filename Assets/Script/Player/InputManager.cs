using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class InputManager
{
    public static bool TouchBegan()
    {
        if (IsPointerOverUI()) return false;

#if UNITY_EDITOR || UNITY_STANDALONE
        return Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump");
#elif UNITY_ANDROID || UNITY_IOS
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
#else
        return false;
#endif
    }

    public static bool IsTouching()
    {
        if (IsPointerOverUI()) return false;

#if UNITY_EDITOR || UNITY_STANDALONE
        return Input.GetMouseButton(0) || Input.GetButton("Jump");
#elif UNITY_ANDROID || UNITY_IOS
        return Input.touchCount > 0 && Input.GetTouch(0).phase != TouchPhase.Ended;
#else
        return false;
#endif
    }

    public static bool TouchEnded()
    {
        if (IsPointerOverUI()) return false;

#if UNITY_EDITOR || UNITY_STANDALONE
        return Input.GetMouseButtonUp(0) || Input.GetButtonUp("Jump");
#elif UNITY_ANDROID || UNITY_IOS
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
#else
        return false;
#endif
    }

    public static bool IsPointerOverUI()
    {
        if (EventSystem.current == null) return false;

#if UNITY_ANDROID || UNITY_IOS
    if (Input.touchCount > 0)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.GetTouch(0).position;

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
    return false;
#else
        return EventSystem.current.IsPointerOverGameObject();
#endif
    }

}
