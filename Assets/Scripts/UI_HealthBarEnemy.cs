using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_HealthBarEnemy : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;
    public Image foreGroundImage;
    public Image backGroundImage;


    private void LateUpdate()
    {
        Vector3 direction = (target.position - Camera.main.transform.position).normalized;
        bool isBehind = Vector3.Dot(direction, Camera.main.transform.forward) < 0.00f;
        foreGroundImage.enabled = !isBehind;
        backGroundImage.enabled = !isBehind;
        transform.position = Camera.main.WorldToScreenPoint(target.position + offSet);
    }


    public void setHealth(float percent)
    {
        float width = GetComponent<RectTransform>().rect.width;
        float currentWidth = width * percent;
        foreGroundImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, currentWidth);
    }
}
