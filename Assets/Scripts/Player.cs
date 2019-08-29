using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        float scale = Random.Range(0.5f, 1.3f);
        transform.localScale = new Vector3(scale, scale, scale);
        speed = Random.Range(5f, 7f);
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        float rotation = Random.Range(transform.rotation.eulerAngles.z + 100, transform.rotation.eulerAngles.z + 260);
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameController.instance.Restart();
        Destroy(gameObject);
    }
}