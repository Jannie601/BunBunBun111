using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTracker : MonoBehaviour
{

	public bool shouldRotate;

	public LayerMask WhatIsPlayer;


	private Rigidbody2D rb;
	private Animator anim;
	private Vector2 movement;
	public Vector3 dir;

	private bool isInChaseRange;
	private bool isInAttackRange;
	private Transform target;



	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		target = GameObject.FindWithTag("Player").transform;
	}
	private void Update()
	{

		dir = target.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		dir.Normalize();
		movement = dir;
		if(shouldRotate)
		{
			anim.SetFloat("X", dir.x);
			anim.SetFloat("Y", dir.y);
		}


	}

}