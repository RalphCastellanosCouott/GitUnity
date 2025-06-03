using UnityEngine;

public class GolpeEvento : MonoBehaviour
{
    public PlayerMove playerMove;
    public void GolpeImpacto()
    {
        if (playerMove != null)
        {
            playerMove.GolpeImpacto();
        }
    }
}