namespace Carmageddon.Forms.Bridge__Shooting_
{
    public class RefinedShootingHandler : AbstractShootingHandler
    {
        public async override Task<string> HandleShot()
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
