using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Menu : MonoBehaviour
{
    public float padding;
    public float width;
    public float height;
    public float xOffset;
    public float yOffset;
    public Sprite background;
    public Sprite topBorder;
    public Sprite bottomBorder;
    public Sprite rightBorder;
    public Sprite leftBorder;
    public Sprite topLeftCorner;
    public Sprite topRightCorner;
    public Sprite bottomLeftCorner;
    public Sprite bottomRightCorner;
    public enum Anchor
    {
        Center,
        TopCenter,
        BottomCenter,
        RightCenter,
        LeftCenter,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public Anchor anchor;

    public List<Menu> subWindows;
}

