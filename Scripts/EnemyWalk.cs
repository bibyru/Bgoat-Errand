using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject[] Points;
    [SerializeField] float speed;
    [SerializeField] float limit;

    Rigidbody2D rigid;
    int index = 0;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Flip()
    {
        Enemy.transform.localScale = new Vector3(-1 * Enemy.transform.localScale.x, Enemy.transform.localScale.y, Enemy.transform.localScale.z);
    }

    private void Update()
    {
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Points[index].transform.position, speed * Time.deltaTime);
        float distance = Vector3.Distance(Enemy.transform.position, Points[index].transform.position);

        if (distance <= limit)
        {
            Flip();
            index++;
            if (index > 1)
            {
                index = 0;
            }
        }
    }
}
