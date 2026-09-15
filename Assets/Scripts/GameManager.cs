using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalCoin;
    private int koinTerkumpul = 0;
    private int jumlahZombieMati = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalCoin = GameObject.FindGameObjectsWithTag("Koin").Length;
    }
    void SaatZombieMati(Enemy zombie)
    {
        jumlahZombieMati++;
        Debug.Log("Dengarkan notifnya. Zombie mati sebanyak " + jumlahZombieMati + "(" + zombie.name + ")");
    }
    public void AmbilCoin()
    {
        koinTerkumpul++;
        if (koinTerkumpul==totalCoin)
        {
            Menang();
        }
    }
    void Menang()
    {
        Debug.Log("KAMU MENANG");
    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = 22;
        GUI.Label(new Rect(16, 16, 480, 36), "Koin: " + koinTerkumpul + " / " + totalCoin);
        GUI.Label(new Rect(16, 52, 480, 36), "Zombie mati: " + jumlahZombieMati);
    }
}
