using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    public float speed;
    public float maxX = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        int tNum = transform.localScale.x > 0 ? 1 : -1;
        transform.position += new Vector3(speed * Time.deltaTime * tNum, 0);
    }

}
