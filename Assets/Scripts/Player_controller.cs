using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    private GameObject player;
    private Collider2D target1; 
    private GameObject target; //Точка для направления движения
    private char dir = ' ';
    private float speed = 0;
    private Collider2D[] coll;
    private Collider2D[] coll_front;
    private static ContactFilter2D contact;

    private void Awake() {
        player = this.gameObject;
        
        target1 = this.transform.GetChild(0).gameObject.GetComponent<Collider2D>();
        target = this.transform.GetChild(0).gameObject;
    }

    private void Update() {
        if (Input.GetAxis("Horizontal") > 0){
            dir = 'R';
            Direction();
        }
        if (Input.GetAxis("Horizontal") < 0) {
            dir = 'L';
            Direction();
        }
        if (Input.GetAxis("Vertical") > 0){
            dir = 'U';
            Direction();
        }
        if (Input.GetAxis("Vertical") < 0){
            dir = 'D';
            Direction();
        }
        coll = Physics2D.OverlapCircleAll(target.transform.position, 0.28f);
        //Vector2 coll_center = new Vector2 (target.transform.position.x, target.transform.position.y);
        //Vector2 coll_size = new Vector2 (0.25f, 0);
        
        //Physics2D.OverlapBoxNonAlloc(coll_center, coll_size, 0, coll);
        //coll = Physics2D.OverlapBoxAll(coll_center, coll_size, 0);
        if (coll.Length > 1){
            ObjectOnPath();
        }
    }

    private void FixedUpdate() {
        Vector3 dir = target.transform.position - this.transform.position;
        dir.z = 0;
        this.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        targets.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    private void Direction(){
        switch (dir){
            case 'R':
            //coll_front = Physics2D.OverlapPointAll(target_R.transform.position);
            //if (coll_front.Length > 0) return;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            break;

            case 'L':
            //coll_front = Physics2D.OverlapPointAll(target_L.transform.position);
            //if (coll_front.Length > 0) return;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            break;

            case 'U':
            //coll_front = Physics2D.OverlapPointAll(target_U.transform.position);
            //if (coll_front.Length > 0) return;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            break;

            case 'D':
            //coll_front = Physics2D.OverlapPointAll(target_D.transform.position);
            //if (coll_front.Length > 0) return;
            transform.rotation = Quaternion.Euler(0, 0, -90);
            break;
        }
        speed = Config.player_speed;
    }

    private void ObjectOnPath(){
        foreach (Collider2D item in coll){
            if (item.gameObject.tag == "Wall"){
                speed = 0;
            } else {
                // Debug.Log("не стена");
            }
        }
    }
}


