namespace Carmageddon.Forms.Bridge__Shooting_
{
    public class RefinedShootingHandler : AbstractShootingHandler
    {
        public async override Task<string> HandleShot(int coordX, int coordY, string username)
        {
            (bool hit, Type type) = await Weapon.Shoot(coordX, coordY, username);

            if (hit)
            {
                return type.Name + "hit";
            }

            return type.Name;
        }
    }
}
