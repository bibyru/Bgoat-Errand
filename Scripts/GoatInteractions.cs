using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoatInteractions : MonoBehaviour
{
    [SerializeField] GameObject Manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            GetComponent<GoatSounds>().AddHeart.Play();
            Manager.GetComponent<Manager>().AddHeart();
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Shrub"))
        {
            GetComponent<GoatSounds>().AddHeart.Play();
            Manager.GetComponent<Manager>().AddShrub();
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Power"))
        {
            GetComponent<GoatSounds>().Bonk.Play();
            collision.gameObject.GetComponent<PowerSpawn>().Execute();
        }

        else if (collision.gameObject.CompareTag("Win"))
        {
            Manager.GetComponent<Manager>().PlayerWin();
            GetComponent<GoatAnimations>().AnimWin(collision.gameObject.transform.GetChild(0).transform.position);
        }

        else if (collision.gameObject.CompareTag("Death"))
        {
            Manager.GetComponent<Manager>().PlayerDied();
        }

        else if (collision.gameObject.CompareTag("EnemyHat"))
        {
            GetComponent<GoatSounds>().Boing.Play();
            //                              Avocado                     Enemy
            collision.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<EnemyDie>().Execute();
            GetComponent<GoatActions>().Jump(true);
        }
        
        else if (collision.gameObject.CompareTag("EnemyDmg"))
        {
            GetComponent<GoatSounds>().LoseHeart.Play();
            GetComponent<GoatActions>().Jump(true, true);
            Manager.GetComponent<Manager>().UseHeart();
        }
    }
}
