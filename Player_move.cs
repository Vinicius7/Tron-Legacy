using UnityEngine;using System.Collections;public class Player_move : MonoBehaviour {

    // Movement keys (now on  Unity Input Manager)

    // Movement Speed
    public float inicialSpeed = 16;    float speed;

    //Aceleration
    public float acelerationRate;

    //Directions
    Vector2 inputDirection = Vector2.zero;    Vector2 currentDirection = Vector2.zero;

    // Wall Prefab
    public GameObject wallPrefab;

    // Current Wall
    Collider2D wall;

    // Last Wall's End
    Vector2 lastWallEnd;



    // Use this for initialization
    void Start () {
        //Set Initial Velocity
        speed = inicialSpeed;        currentDirection = Vector2.up;        GetComponent<Rigidbody2D>().velocity = currentDirection * speed;        spawnWall();        }    void spawnWall () {
        // Save last wall's position
        lastWallEnd = transform.position;
        // Spawn a new Lightwall
        GameObject g = (GameObject) Instantiate(wallPrefab,transform.position,Quaternion.identity);        wall = g.GetComponent<Collider2D>();        }    void fitColliderBetween (Collider2D co,Vector2 a,Vector2 b) {
        // Calculate the Center Position
        co.transform.position = a + (b - a) * 0.5f;

        // Scale it (horizontally or vertically)
        float dist = Vector2.Distance(a,b);        if (a.x != b.x)            co.transform.localScale = new Vector2(dist + 1,1);        else            co.transform.localScale = new Vector2(1,dist + 1);        }

    // Update is called once per frame
    void Update () {        //Input        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;


        //Debug
        print(GetComponent<Rigidbody2D>().velocity);

        //Speed up
        if (Input.GetAxis("Fire1")>0)
            GetComponent<Rigidbody2D>().velocity += (currentDirection * acelerationRate);


        // Check for key presses
        if (inputDirection.y == 1 && currentDirection.y == 0) {            currentDirection = Vector2.up;            GetComponent<Rigidbody2D>().velocity = currentDirection * speed;            spawnWall();            }        else if (inputDirection.y == -1 && currentDirection.y == 0) {            currentDirection = Vector2.down;            GetComponent<Rigidbody2D>().velocity = currentDirection * speed;            spawnWall();            }        else if (inputDirection.x == 1 && currentDirection.x == 0) {            currentDirection = Vector2.right;            GetComponent<Rigidbody2D>().velocity = currentDirection * speed;            spawnWall();            }        else if (inputDirection.x == -1 && currentDirection.x == 0) {            currentDirection = Vector2.left;            GetComponent<Rigidbody2D>().velocity = currentDirection * speed;            spawnWall();            }        fitColliderBetween(wall,lastWallEnd,transform.position);        }    void OnTriggerEnter2D (Collider2D co) {
        // Not the current wall?
        if (co != wall) {            print("Player lost:" + name);            Destroy(gameObject);            }        }
    }