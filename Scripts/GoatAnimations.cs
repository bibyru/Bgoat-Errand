using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatAnimations : MonoBehaviour
{
    [SerializeField] GameObject cam;

    Animator theanimator;
    Rigidbody2D rigid;
    bool win = false;

    Vector2 collidersmol = new Vector2(0.04f, 0.067f);
    Vector2 colliderbig = new Vector2(0.06f, 0.15f);

    private void Start()
    {
        theanimator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

        GetComponent<BoxCollider2D>().size = collidersmol;
    }

    private void Update()
    {
        if (win == false) {
            if ((int) rigid.velocity.x == 0)
            {
                AnimIdle();
            }
            else if ((int) rigid.velocity.x > 0)
            {
                Flip(1);
                AnimRun();
            }
            else if ((int) rigid.velocity.x < 0)
            {
                Flip(-1);
                AnimRun();
            }
        }
    }

    public void Flip(int dir)
    {
        if (dir == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void Weregoat()
    {
        GetComponent<GoatActions>().Jump(true, true);

        if (theanimator.GetBool("smol") == false)
        {
            theanimator.SetBool("smol", true);
            GetComponent<BoxCollider2D>().size = collidersmol;
            GetComponent<GoatActions>().checksize = GetComponent<GoatActions>().checksizesmol;
        }
        else
        {
            theanimator.SetBool("smol", false);
            GetComponent<BoxCollider2D>().size = colliderbig;
            GetComponent<GoatActions>().checksize = GetComponent<GoatActions>().checksizebig;
        }
    }

    public void AnimIdle()
    {
        theanimator.SetInteger("anim", 0);
    }

    public void AnimRun()
    {
        theanimator.SetInteger("anim", 1);
    }

    public void AnimWin(Vector3 overhere)
    {
        win = true;

        GetComponent<GoatActions>().enabled = false;
        GetComponent<PlayerInput>().enabled = false;
        rigid.velocity = Vector3.zero;

        float zcam = cam.GetComponent<CameraFollow>().transform.position.z;
        float ylock = cam.GetComponent<CameraFollow>().ylock;
        cam.GetComponent<CameraFollow>().enabled = false;
        cam.transform.position = new Vector3(overhere.x, ylock, zcam);

        transform.position = overhere;
        theanimator.SetInteger("anim", 2);
    }
}
