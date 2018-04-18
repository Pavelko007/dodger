using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float speed = 5;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetMouseButton(0))
	    {
	        var clickPosWorld = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
	        transform.position = clickPosWorld;
	    }

	    //if (Input.touchCount > 0)
	    //{
	    //    Debug.Log("detected touch");
	    //}
     //   var hor = Input.GetAxis("Horizontal")  ;
	    //Vector3 moveDir;
	    //if (hor > 0)
	    //{
	    //    moveDir = Vector3.right;

	    //}
     //   else if (hor < 0)
	    //{
	    //    moveDir = Vector3.left;
	    //}
	    //else return; 

	    //transform.Translate(moveDir * speed * Time.deltaTime);
        

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
    }
}
