using UnityEngine;
using System;
using UnityEngine.AdaptivePerformance;
public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    public float ms = 2f;
    protected Transform player;
    [Header("State Machine")]
    [SerializeField] private float JarakDeteksi = 6f;
    [SerializeField] private float JarakSerang = 1.5f;
    [SerializeField] private float JedaSerang = 1f;

    // State Now
    private StateEnemy state = StateEnemy.IDLE;
    private float waktuSerangTerakhir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj!=null)
        {
            player = playerObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PeriksaTransisi();
        switch (state)
        {
            case StateEnemy.IDLE:
                PerilakuIdle();
                break;
            case StateEnemy.PATROL:
                PerilakuPatrol();
                break;
            case StateEnemy.CHASE:
                PerilakuChase();
                break;
            case StateEnemy.ATTACK:
                PerilakuAttack();
                break;
        }
    }
    public float JarakKePlayer()
    {
        if (player == null) return Mathf.Infinity;
        return Vector2.Distance(transform.position, player.transform.position);
    }
    void PeriksaTransisi()
    {
        float jarak = JarakKePlayer();

        if (jarak <= JarakSerang)
        {
            state = StateEnemy.ATTACK;
        }
        else if (jarak <= JarakDeteksi)
        {
            state = StateEnemy.CHASE;
        }
        else
        {
            state = StateEnemy.PATROL;
        }
    }
    public void Kejar()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            ms * Time.deltaTime
        );
    }

    public virtual void Serang()
    {
        Debug.Log("Enemy Serang");
    }

    // Dipanggil otomatis oleh Unity saat collider enemy menabrak collider lain.
    // Karena ada di class induk, SEMUA turunan zombie ikut punya perilaku ini.
    void PerilakuIdle()
    {
        Debug.Log("Enemy sedang IDLE");
    }

    void PerilakuPatrol()
    {
        Debug.Log("Enemy sedang PATROL");
    }

    void PerilakuChase()
    {
        Kejar();
        Debug.Log("Enemy sedang CHASE");
    }

    void PerilakuAttack()
    {
        Debug.Log("Enemy sedang ATTACK");
    }

}
