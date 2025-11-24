using Player;
using UnityEngine;


namespace Controllers
{
    public abstract class InputController : ScriptableObject
    {
        public abstract Vector2 RetrieveMoveInput();

        public abstract int RetrieveWeaponInput();
        
        public abstract WeaponType RetrieveWeaponSwitchInput();
    }
}
