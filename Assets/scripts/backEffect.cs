using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backEffect : MonoBehaviour
{
    public Camera cam;
    public Transform trans;
    Vector2 startPosiotion;
    float startZ;

    //�������trans����
    private float zDistance => transform.position.z - trans.transform.position.z;


    void Start()
    {
        startPosiotion = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // ����ƶ��������ʼ���룬��ȡ���ƫ�ƾ���
        Vector2 camMove = (Vector2)cam.transform.position - startPosiotion;

        //��ȡ����ǰ���Ǻ�,���ǰ�ý��ü��棬����Զ�ü���
        float clippingPlane = cam.transform.position.z + (zDistance > 0 ? cam.farClipPlane : cam.nearClipPlane);

        //�����Ӳ�����
        float parallaxFactor = Mathf.Abs(zDistance) / clippingPlane;

        //��ȡ������Ҫƫ�Ƶ�x,yλ��
        Vector2 backgroundPos = startPosiotion + camMove * parallaxFactor;

        //��Ϊ��2d������z����
        Vector3 newPosition = new Vector3(backgroundPos.x, backgroundPos.y, startZ);

        transform.position = newPosition;
    }
}
