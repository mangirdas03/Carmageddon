using System.Diagnostics;
using Microsoft.AspNetCore.SignalR.Client;

namespace Carmageddon.Forms.Models
{
    public class MachineGun : Weapon
    {
        public async override Task<(bool, Type)> Shoot(string coords)
        {
            bool isHit = false;
            await foreach (var hit in BattleHub.StreamAsync<bool>("CheckShot", typeof(MachineGun).Name, coords))
            {
                isHit = hit;
                break;
            }
            ShotsLeft--;
            Debug.WriteLine("Machinegun shot made!");
            if(isHit)
            {
                Debug.WriteLine("Enemy hit!");
            }

            return (isHit, typeof(MachineGun));
        }
    }
}
