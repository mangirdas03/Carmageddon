using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Models
{
    public class Cannon : Weapon
    {
        public async override Task<(bool, Type)> Shoot()
        {
            bool isHit = false;
            await foreach (var hit in BattleHub.StreamAsync<bool>("CheckShot", typeof(Cannon).Name))
            {
                isHit = hit;
                break;
            }
            ShotsLeft--;
            Debug.WriteLine("Cannon shot made!");
            if (isHit)
            {
                Debug.WriteLine("Enemy hit!");
            }

            return (isHit, typeof(Cannon));

        }
    }
}
