using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public float checkRadius;
	public float attackRadius;

	public bool shouldRotate;

	public LayerMask WhatIsPlayer;


	private Rigidbody2D rb;
	private Animator anim;
	private Vector2 movement;
	public Vector3 dir;

	private bool isInChaseRange;
	private bool isInAttackRange;

	public float speed = 3f;
	private Transform target;

	private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.tag == "Player")
			{
				target = transform;
			}
		}

	private void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject.tag == "Player")
			{
				target = null;
			}
		}


	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		target = GameObject.FindWithTag("Player").transform;
	}
	private void Update()
	{

		if (target !=null)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, target.position, step);
		}

		anim.SetBool("isRunning", isInChaseRange);

		isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, WhatIsPlayer);
		isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, WhatIsPlayer);

		dir = target.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		dir.Normalize();
		movement = dir;
		if(shouldRotate)
		{
			anim.SetFloat("x", dir.x);
			anim.SetFloat("y", dir.y);
		}


	}

	private void FixedUpdate()
	{
		if(isInChaseRange && !isInAttackRange)
		{
			MoveCharacter(movement);
		}
		if(isInAttackRange)
		{
			rb.velocity = Vector2.zero;
		}
	}

	private void MoveCharacter(Vector2 dir)
	{
		rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));	
	}
}