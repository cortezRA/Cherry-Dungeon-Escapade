using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private int health = 3;
    [SerializeField] private int immunityDuration = 2;
    [SerializeField] private float immunityDeltaTime = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Hazard") && health - 1 == 0)
        {
            health--;
            Die();
        }
        else if (collision.gameObject.CompareTag("Hazard"))
        {
            anim.SetTrigger("gethit");
            health--;
            StartCoroutine(BecomeTemporarilyInvincible());
        }

    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        anim.SetBool("immunity", true);

        for (float i = 0; i < immunityDuration; i += immunityDeltaTime)
        {
            yield return new WaitForSeconds(immunityDeltaTime);
        }
        anim.SetBool("immunity", false);
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        SceneManager.LoadScene("GameOver");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
