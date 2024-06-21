using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FindPlayer : MonoBehaviour
{
    public UnityEvent ue;

    public float moveSpeed = 2.5f;

    private Collider2D player;

    public GameObject enemy;

    private Vector3 StartPosition;

    public FlyingEye capsuleCollider2;

    private bool IsFindPlayer = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        StartPosition = enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFindPlayer && player)
        {
            moveTo(player.transform.position, moveSpeed);
        }
        else
        {
            if (StartPosition != enemy.transform.position)
            {
                moveTo(StartPosition, moveSpeed + 3);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            IsFindPlayer = true;
            player = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            IsFindPlayer = false;
            player = null;
        }
    }

    private void moveTo(Vector3 targetPosition, float speed)
    {
        if (capsuleCollider2)
        {
            if (!capsuleCollider2.damageable.IsAlive)
            {
                return;
            }
            if (capsuleCollider2.lockPosition)
            {
                return;
            }
        }
        Vector3 currentPosition = enemy.transform.position;
        Vector3 direction = (targetPosition - currentPosition).normalized; // 计算方向向量并归一化
        float distance = Vector3.Distance(currentPosition, targetPosition); // 计算当前距离到目标的距离

        if (direction.x < 0)
        {
            enemy.transform.localScale *= new Vector2(enemy.transform.localScale.x > 0 ? -1 : 1, 1);
        }
        else
        {
            enemy.transform.localScale *= new Vector2(enemy.transform.localScale.x > 0 ? 1 : -1, 1);
        }
        // 计算当前帧移动的距离
        float step = speed * Time.deltaTime;

        // 如果当前帧移动的距离大于剩余的距离，则直接移动到目标位置
        if (step < distance - 1.2f)
        {
            // 按照方向移动一步
            enemy.transform.position = currentPosition + direction * step;
            ue?.Invoke();
        }
        else
        {

        }
    }
}
