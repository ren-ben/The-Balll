using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    #region Variables
    public GameObject effect;
    public int Damege = 1;
    public static float speed = 5f;
    public static float DefaultSpeed = 5f;
    public Animator camAnim;
    #endregion

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("Shake");
 
            //Player is taking damege
            Destroy(gameObject);
        }
    }
}
