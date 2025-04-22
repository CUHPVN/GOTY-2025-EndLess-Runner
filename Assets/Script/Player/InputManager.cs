using UnityEngine;
using UnityEngine.EventSystems;

public static class InputManager
{
    public static bool TouchBegan()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        bool mouseDown = Input.GetMouseButtonDown(0);
        bool jumpDown = Input.GetButtonDown("Jump");

        // Nếu là click chuột → phải kiểm tra có va vào UI không
        if (mouseDown && IsPointerOverUI()) return false;

        return mouseDown || jumpDown;
#elif UNITY_ANDROID || UNITY_IOS
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
        if (IsPointerOverUI()) return false;
        return true;
    }
    return false;
#else
    return false;
#endif
    }


    public static bool IsTouching()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        bool mouseHeld = Input.GetMouseButton(0);
        bool jumpHeld = Input.GetButton("Jump");

        if (mouseHeld && IsPointerOverUI()) return false;

        return mouseHeld || jumpHeld;
#elif UNITY_ANDROID || UNITY_IOS
    if (Input.touchCount > 0 && Input.GetTouch(0).phase != TouchPhase.Ended)
    {
        if (IsPointerOverUI()) return false;
        return true;
    }
    return false;
#else
    return false;
#endif
    }

    public static bool TouchEnded()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        bool mouseUp = Input.GetMouseButtonUp(0);
        bool jumpUp = Input.GetButtonUp("Jump");

        if (mouseUp && IsPointerOverUI()) return false;

        return mouseUp || jumpUp;
#elif UNITY_ANDROID || UNITY_IOS
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
    {
        if (IsPointerOverUI()) return false;
        return true;
    }
    return false;
#else
    return false;
#endif
    }
    public static bool IsPointerOverUI()
    {
#if UNITY_ANDROID || UNITY_IOS
        // Kiểm tra touch đầu tiên có nhấn lên UI không
        if (Input.touchCount > 0)
        {
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        }
        else
        {
            return false;
        }
#else
        return EventSystem.current.IsPointerOverGameObject();
#endif
    }
}
