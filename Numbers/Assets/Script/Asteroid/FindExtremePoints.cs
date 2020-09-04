using UnityEngine;

public class FindExtremePoints : MonoBehaviour
{
    private float Xr { get; set; }
    private float Yt { get; set; }
    private float Yb { get; set; }
    private void Start()
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
