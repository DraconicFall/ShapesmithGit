using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public float time;
    public GameObject deathEffect;
    bool calledDeathScript = false;
    public bool destroyWhenEIsPressed = false;
    public bool ifChildIsDestroyed = false;
    public bool ifEnemyAmountIsZero = false;
    public int amountOfChild = 0;
    bool checkedNumOfEnemies = false;
    // Start is called before the first frame update
    void Start()
    {
        amountOfChild = transform.childCount;
        if (ifEnemyAmountIsZero)
        {
            StartCoroutine(checkNumOfEnemies());
        }
    }

    private void Update()
    {
        if (checkedNumOfEnemies && EnemyScript.numOfEnemies <= 0)
        {
            StartCoroutine(death());
        }
        amountOfChild = transform.childCount;
        if (ifChildIsDestroyed == true && amountOfChild <= 0)
        {
            Destroy(gameObject);
        }
        if (destroyWhenEIsPressed == true && Input.GetKey(KeyCode.E))
        {
            Destroy(gameObject);
        }
        if (!ifEnemyAmountIsZero && calledDeathScript == false)
        {
            calledDeathScript = true;
            StartCoroutine(death());
        }
    }

    IEnumerator checkNumOfEnemies()
    {
        yield return new WaitForSeconds(0.1f);
        checkedNumOfEnemies = true;
    }
    // Update is called once per frame
    IEnumerator death()
    {
        yield return new WaitForSeconds(time);
        if (deathEffect != null )
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
