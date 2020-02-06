using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMvScript : MonoBehaviour
{
    public float CurMvSpd, BaseMvSpd, ModMvSpd;
    public bool isCarry;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        fncMvMode(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    fncMvMode(!isCarry);
        //}
    }

    void FixedUpdate()
    {

        fncMove();
    }

    public void fncMvMode(bool x)
    {
        isCarry = x;
        if (isCarry) CurMvSpd = BaseMvSpd * ModMvSpd;
        else CurMvSpd = BaseMvSpd * ModMvSpd;
    }
    void fncMove()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) ;
        transform.position += dir * CurMvSpd * Time.fixedDeltaTime;
        if(dir.x != 0 || dir.y != 0)
        {
           anim.SetBool("Walking",true);
           if(dir.x > 0) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x)* -1, transform.localScale.y);
           else if(dir.x < 0) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) ,transform.localScale.y);
        }
        else{
            anim.SetBool("Walking",false);
        }
        //in case standard transform position overshoots or doesn't collide
        //GetComponent<Rigidbody>().MovePosition(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * MvSpd * Time.fixedDeltaTime);
    }
}
