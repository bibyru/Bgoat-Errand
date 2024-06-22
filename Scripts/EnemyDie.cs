using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    [SerializeField] GameObject Manager;
    [SerializeField] int myworth = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyDeath"))
        {
            Execute(false);
        }
    }

    public void Execute(bool getscore = true)
    {
        if (getscore == true)
        {
            Manager.GetComponent<Manager>().AddScore(myworth);
        }
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
