﻿using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.AbstractFactory
{
    public class MediumAmmoFactory : WeaponFactory
    {
        public override Cannon CreateCannon()
        {
            return new Cannon()
            {
                Damage = 3,
                ShotsLeft = 2
            };
        }

        public override MachineGun CreateMachineGun()
        {
            return new MachineGun()
            {
                Damage = 2,
                ShotsLeft = 2
            };
        }
    }
}