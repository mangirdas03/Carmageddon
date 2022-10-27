namespace Carmageddon.Forms.Bridge__Shooting_
{
    public class RefinedShootingHandler : AbstractShootingHandler
    {
        public async override Task<string> HandleShot(string coords)
        {
            (bool hit, Type type) = await Weapon.Shoot(coords);

            if (hit)
            {
                return type.Name + "hit";
            }

            return type.Name;
        }
    }
}
