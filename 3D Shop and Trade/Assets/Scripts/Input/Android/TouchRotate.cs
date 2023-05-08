using UnityEngine;
public class TouchRotate : RotateInput
{
    [SerializeField] private RectTransform ignoreRect;
    private Vector2 _prevTouchPos;

    private void Update()
    {
        if (TryGetTouch(out Touch touch))
        {
            if (CanRotate(touch))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _prevTouchPos = touch.position;
                }
                RotateTouch(touch);
            }
        }
    }

    private bool TryGetTouch(out Touch touch)
    {
        touch = default;
        if (Input.touchCount == 0) return false;
        touch = Input.GetTouch(0);
        return true;
    }

    private void RotateTouch(Touch touch)
    {
        if (touch.phase == TouchPhase.Moved)
        {
            Vector2 touchDelta = touch.position - _prevTouchPos;
            RotateEntity(touchDelta.x);
            RotateCamera(touchDelta.y);
            _prevTouchPos = touch.position;
        }
    }
    private bool CanRotate(Touch touch) =>
        RectTransformUtility.RectangleContainsScreenPoint(ignoreRect, touch.position) == false;
}