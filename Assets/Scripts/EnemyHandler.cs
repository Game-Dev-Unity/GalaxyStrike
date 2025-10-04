using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyShipVFX;
    Scoreboard scoreboard;
    int hitPoint = 3;
    int score = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnParticleCollision(GameObject other)
    {
        --hitPoint;
        if (hitPoint <= 0)
        {
            scoreboard.IncrementScore(score);
            Instantiate(destroyShipVFX, this.transform.position, Quaternion.identity);
            Destroy(this.transform.parent.gameObject);
        }        
    }
}
