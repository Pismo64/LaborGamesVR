using UnityEngine;
using UnityEngine.UI;

public class Bot3Script : MonoBehaviour
{
    [Header("Health")]
    public int health = 60;
    private int maxHealth = 60;

    [Header("Healthbar")]
    public Slider healthbar;

    [Header("Explosion")]
    public ParticleSystem explosion;
    public Transform botPosition;


    // Start is called before the first frame update
    void Start()
    {
        healthbar.maxValue = maxHealth;
        health = maxHealth;
        healthbar.value = health;
        healthbar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0)
        {
            healthbar.gameObject.SetActive(false);
            return;
        }

        health -= damage;
        healthbar.value = health;
        healthbar.gameObject.SetActive(true);
    }

    public void Explode ()
    {
        Instantiate(explosion, botPosition.position, botPosition.rotation);
        Destroy(gameObject);
    }
}
