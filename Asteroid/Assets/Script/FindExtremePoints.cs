using UnityEngine;

public class FindExtremePoints : MonoBehaviour
{
    private float Xr;
    private float Yt;
    private float Yb;
    public float XRight
    { get { return Xr; } }
    public float YTop
    { get { return Yt; } }
    public float YBot
    { get { return Yb; } }
    private void Awake()
    {
        RectTransform _changeTransform = transform as RectTransform;

        Xr = _changeTransform.position.x + _changeTransform.sizeDelta.x / 2;//
        Yt = _changeTransform.position.y + _changeTransform.sizeDelta.y / 2;//
        Yb = _changeTransform.position.y - _changeTransform.sizeDelta.y / 2;//получение крайних точек прямоугольника
    }

    // Update is called once per frame
    void Update()
    {

    }
}