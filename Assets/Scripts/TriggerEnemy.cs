using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    private float speed = 0f;
    private float maxspeed = Config.ghost_speed;
    private GameObject player;
    private GameObject target;
    private GameObject enemy;
    

    private void Awake() {
        player = GameObject.Find("Pacman");
        target = this.transform.parent.transform.GetChild(0).gameObject;
        enemy = this.transform.parent.gameObject;
    }
    private void Start() {
        enemy.transform.position = new Vector3(player.transform.position.x + 5 ,player.transform.position.y + 5 ,1);
    }
    private void FixedUpdate() {
        Vector3 dir = target.transform.position - enemy.transform.position;
        dir.z = 1;
        enemy.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print(other.tag);
        if (other.gameObject.tag == "Player")
        {
            speed = Config.ghost_speed;
        }
        //print("Столкновение");
    }
    private void OnTriggerExit2D(Collider2D other) {
        print(other.tag);
        if (other.gameObject.tag == "Player")
        {
            speed = 0f;
        }
    }

    public void ChangeDirection()
    {
        int r = UnityEngine.Random.Range(1, 5);
            switch(r)
            {
                case 1:
                    Direction('U');
                break;
                case 2:
                    Direction('L');
                break;
                case 3:
                    Direction('D');
                break;
                case 4:
                    Direction('R');
                break;
            }
    }
    void Direction(char dir)
    {
        switch(dir)
        {
            case 'U':
                enemy.transform.rotation = Quaternion.Euler(0, 0, 90);
            break;

            case 'L':
                enemy.transform.rotation = Quaternion.Euler(0, 0, 180);
            break;

            case 'D':
                enemy.transform.rotation = Quaternion.Euler(0, 0, -90);
            break;

            case 'R':
                enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
            break;
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T)) Direction('U');
        if(Input.GetKeyDown(KeyCode.F)) Direction('L');
        if(Input.GetKeyDown(KeyCode.G)) Direction('D');
        if(Input.GetKeyDown(KeyCode.H)) Direction('R');
    }
}
