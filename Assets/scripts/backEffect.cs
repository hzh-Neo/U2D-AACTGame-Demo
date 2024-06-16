using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backEffect : MonoBehaviour
{
    public Camera cam;
    public Transform trans;
    Vector2 startPosiotion;
    float startZ;

    //此物距离trans距离
    private float zDistance => transform.position.z - trans.transform.position.z;


    void Start()
    {
        startPosiotion = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // 相机移动距离减初始距离，获取相机偏移距离
        Vector2 camMove = (Vector2)cam.transform.position - startPosiotion;

        //获取人物前还是后,相机前用近裁剪面，后用远裁剪面
        float clippingPlane = cam.transform.position.z + (zDistance > 0 ? cam.farClipPlane : cam.nearClipPlane);

        //计算视差因子
        float parallaxFactor = Mathf.Abs(zDistance) / clippingPlane;

        //获取背景需要偏移的x,y位置
        Vector2 backgroundPos = startPosiotion + camMove * parallaxFactor;

        //因为是2d，所以z不变
        Vector3 newPosition = new Vector3(backgroundPos.x, backgroundPos.y, startZ);

        transform.position = newPosition;
    }
}
