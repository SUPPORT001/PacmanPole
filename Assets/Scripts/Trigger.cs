using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private GameObject player;

    private void Awake() {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("контакт");
    }
}
