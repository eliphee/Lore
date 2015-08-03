using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lore
{
    class Character
    {
        private string _name;

        private int _strength;
        private int _magic;
        private int _eye;
        private int _spikeyball;

        private int _movement;
        private int _life;
        private int _stamina;
        private int _defence;

        Character(string name, int str, int mag, int eye, int spk, int mov, int lif, int sta, int def)
        {
            _name = name;
            _strength = str;
            _magic = mag;
            _eye = eye;
            _spikeyball = spk;
            _movement = mov;
            _life = lif;
            _stamina = sta;
            _defence = def;
        }

        public bool GetDamage(int amountDMG)
        {
            _life = _life - amountDMG;
            if (_life > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
