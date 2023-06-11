using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] float deathPlane = -.5f;
    bool isDead = false;
    float reloadTime = 1f;
    [SerializeField] AudioSource deathSound;
    public void Update()
    {
        if(transform.position.y < deathPlane && !isDead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("EnemyBody"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    private void Die()
    {
        deathSound.Play();
        Invoke( nameof(ReloadLevel), reloadTime);
        isDead = false;
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
