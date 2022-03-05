using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private GameObject target;
    private float speed = Config.ghost_speed;
    private GameObject Pl;

    private void Awake() {
        target = this.transform.GetChild(0).gameObject;
        Pl = GameObject.Find("Player").gameObject;
        
    }

    private void FixedUpdate() {
        
        //this.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        Direction();
    }

    private void Direction()
    {
        Vector3 dir = Pl.transform.position - this.transform.position;
        //print(Pl.transform.position);
        dir.z = 1;
        dir = dir.normalized;
        
        if (Mathf.Abs(dir.x) >= Mathf.Abs(dir.y))
        {
            this.transform.position += new Vector3(dir.x * speed * Time.deltaTime, 0, 0);
        }
        else
        {
            this.transform.position += new Vector3(0, dir.y * speed * Time.deltaTime, 0);
        }

        //print(dir + "@@@" + dir.normalized);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Wall"){
            //print("Смена направления");
            // this.gameObject.GetComponent<TriggerEnemy>().ChangeDirection();
        }
        // print("Вызов метода!");
    }
}
