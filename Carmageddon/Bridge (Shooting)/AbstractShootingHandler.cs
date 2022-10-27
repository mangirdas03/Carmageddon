using Carmageddon.Forms.Models;

namespace Carmageddon.Forms.Bridge__Shooting_
{
    public abstract class AbstractShootingHandler
    {
        public Weapon Weapon { get; set; }

        public async virtual Task<string> HandleShot()
        {
            (bool hit, Type type) = await Weapon.Shoot();

            if (hit)
            {
                return type.Name + "hit";
            }

            return type.Name;
        }
    }
}
