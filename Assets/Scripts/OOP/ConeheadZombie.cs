using UnityEngine;

public class ConeheadZombie : Enemy
{
    public bool cone = true;
    public override void Serang()
    {
        Debug.Log("Cone Gigit");
    }
}
