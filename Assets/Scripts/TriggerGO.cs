using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGO : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Wall"){
            print("Смена направления");
            // this.gameObject.GetComponent<TriggerEnemy>().ChangeDirection();
        }
        // print("Вызов метода!");
    }
}
