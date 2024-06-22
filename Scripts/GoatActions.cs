using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GoatActions : MonoBehaviour
{
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask LayerGround;
    [SerializeField] float speed = 300f;
    [SerializeField] float jumpforce = 21.5f;
    [SerializeField] float accel = 500f;
    [SerializeField] float friction = 300f;

    Rigidbody2D rigid;
    public float checksize = 0.5f;
    public float checksizesmol = 0.5f;
    public float checksizebig = 0.8f;
    float localspeed = 5f;
    float dir;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        checksize = checksizesmol;
    }

    public void SetDir(float dir)
    {
        this.dir = dir;

        if (this.dir != 0)
        {
            if (localspeed < speed)
            {
                localspeed += accel * Time.deltaTime;
            }
        }
        else
        {
            if (localspeed > 0)
            {
                localspeed -= friction * Time.deltaTime;
            }
        }
    }

    public void Run()
    {
        rigid.velocity = new Vector2(localspeed * Time.deltaTime * dir, rigid.velocity.y);
    }

    public void Jump(bool forced = false, bool halfjump = false)
    {
        if (forced == true)
        {
            if (halfjump == true)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpforce/2);
            }
            else
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpforce);
            }
            GetComponent<GoatSounds>().Jump.Play();
        }
        else
        {
            if (IsOnFloor() == true)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpforce);
            }
            GetComponent<GoatSounds>().Jump.Play();
        }
    }

    private bool IsOnFloor()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, checksize, LayerGround);
    }
}
