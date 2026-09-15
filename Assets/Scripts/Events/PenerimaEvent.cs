using UnityEngine;

public class PenerimaEvent : MonoBehaviour
{
    private void OnEnable()
    {
        PemancarEvent.OnTekanSpasi += Reaksi;
    }
    private void OnDisable()
    {
        PemancarEvent.OnTekanSpasi -= Reaksi;
    }
    void Reaksi()
    {
        Debug.Log("Dengarkan notifnya...");
    }
}
