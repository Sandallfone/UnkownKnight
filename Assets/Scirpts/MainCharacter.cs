using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private Vector2 CharacterMovment;
    public float MovmentSpeed;
    public float JumpForce;
    public static MainCharacter S;
    private Animator CharacterAnim;
    public float TimerJump;
    private float resetTime;
    private bool CanJump;
    private string FootTouched;
    public bool JumpFlag
    {
        get
        {
            return CanJump;
        }
    }
    public string WhatCharacterTouched
    {
        get
        {
            return FootTouched;
        }
    }
    void Start ()
    {
        S = this;
        CharacterAnim = GetComponent<Animator>();
        resetTime = TimerJump;
    }
	void Update ()
    {
        MoveLeftAndRight();
        Jump();
        Attack();
    }

    private void MoveLeftAndRight()
    {
        CharacterMovment = this.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CharacterMovment.x -= MovmentSpeed * Time.deltaTime;
            this.transform.position = CharacterMovment;
            //Debug.Log("Moving Left");
            this.GetComponent<SpriteRenderer>().flipX = true;
            CharacterAnim.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            CharacterMovment.x += MovmentSpeed * Time.deltaTime;
            this.transform.position = CharacterMovment;
            this.GetComponent<SpriteRenderer>().flipX = false;
            CharacterAnim.SetBool("Run", true);
        }
        else
        {
            CharacterAnim.SetBool("Run", false);
        }
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CanJump = true;
        }
        if (Input.GetKey(KeyCode.Space) && CanJump)
        {
            TimerJump -= Time.deltaTime;
            if (TimerJump >= 0.0f)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce)*Time.deltaTime);
                CharacterAnim.SetBool("Jump", true);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            CharacterAnim.SetBool("Jump", false);
            TimerJump = resetTime;
            CanJump = false;
        }
        FootTouched = other.tag;
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CharacterAnim.SetTrigger("Attack");
            //Collider2D[] hitObject = Physics2D.OverlapCircleAll(transform.position, 1.0f);
            //if (hitObject.Length > 1)
            //{
            //hitObject[2].SendMessage("TakeDamamge", 10, SendMessageOptions.DontRequireReceiver);

            //}
            Collider2D[] hitObject = Physics2D.OverlapBoxAll(transform.position+new Vector3(transform.position.x+20,transform.position.y,0), new Vector2(20, 3), 0);
            for (int i = 0; i < hitObject.Length; i++)
            {
                if (hitObject[i].tag == "Enemy")
                {
                    hitObject[i].SendMessage("TakeDamamge", 10, SendMessageOptions.DontRequireReceiver);
                    Debug.Log(hitObject[i].name);
                }
            }
        }
    }
}