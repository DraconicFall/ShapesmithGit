using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTowards : MonoBehaviour
{
    public string objName;
    public float turnSpeed;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find(objName).transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle(transform.eulerAngles.z, angle, turnSpeed * Time.deltaTime));
    }
}
