using UnityEngine;using System.Collections;public class Player_move : MonoBehaviour {    public KeyCode upKey;    public KeyCode downKey;    public KeyCode rightKey;    public KeyCode leftKey;    // Use this for initialization    void Start () {		}		// Update is called once per frame	void Update () {
        // Check for key presses
        if (Input.GetKeyDown(upKey)) {
            // Do stuff...
            }
        else if (Input.GetKeyDown(downKey)) {
            // Do stuff...
            }
        else if (Input.GetKeyDown(rightKey)) {
            // Do stuff...
            }
        else if (Input.GetKeyDown(leftKey)) {
            // Do stuff...
            }
        }}