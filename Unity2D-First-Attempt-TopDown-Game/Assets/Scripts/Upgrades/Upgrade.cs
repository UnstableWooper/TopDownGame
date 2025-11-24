using Enemy;
using UnityEngine;

namespace Upgrades
{
    public class Upgrade : MonoBehaviour
    {
        [SerializeField]private GameObject[] cards;
        
        [SerializeField]private float upgradeCardCount;
        
        public void NewRound()
        {
            float spacing = -7.5f;
            for (int i = 0; i < upgradeCardCount; i++)
            {
                int randCard = Random.Range(0, cards.Length);
                Instantiate(cards[randCard], new Vector3(spacing, 0, 0), Quaternion.identity);
                spacing += 5;
            }
        }
    }
}
