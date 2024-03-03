using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Hp;
    public float Damage;
    public float AtackSpeed;
    public float AttackRange = 2;

    private float lastAttackTime = 0;
    private bool isDead = false;
    public Animator AnimatorController;
    private float speed = 5.0f;

    private void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (isDead)
        {
            return;
        }

        if (Hp <= 0)
        {
            Die();
            return;
        }


        var enemies = SceneManager.Instance.Enemies;
        Enemie closestEnemie = null;

        for (int i = 0; i < enemies.Count; i++)
        {
            var enemie = enemies[i];
            if (enemie == null)
            {
                continue;
            }

            if (closestEnemie == null)
            {
                closestEnemie = enemie;
                continue;
            }

            var distance = Vector3.Distance(transform.position, enemie.transform.position);
            var closestDistance = Vector3.Distance(transform.position, closestEnemie.transform.position);

            if (distance < closestDistance)
            {
                closestEnemie = enemie;
            }

        }

        // Removed auto attack
        if (Input.GetMouseButtonDown(0))
        {
            var distance = Vector3.Distance(transform.position, closestEnemie.transform.position);
            if (Time.time - lastAttackTime > AtackSpeed)
            {
                //transform.LookAt(closestEnemie.transform);
                transform.transform.rotation = Quaternion.LookRotation(closestEnemie.transform.position - transform.position);

                lastAttackTime = Time.time;
                closestEnemie.Hp -= Damage;
                AnimatorController.SetTrigger("Attack");
            }
  
        }
    }

    private void Die()
    {
        isDead = true;
        AnimatorController.SetTrigger("Die");

        SceneManager.Instance.GameOver();
    }


}
