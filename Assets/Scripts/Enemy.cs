using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

  
}
