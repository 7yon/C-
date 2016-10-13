using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Personage
    {
        public int HitPoints { get; set; }
        public int Health { get; set; }
        public int SpeedMovement { get; set; }
        public int SpeedRegenerationOfMana { get; set; }
        public int Mana { get; set; }

        private Dictionary<int, Ability> abilities = new Dictionary<int, Ability>();
        private List<Effect> effects = new List<Effect>();

        Personage()
        {
        }

        public void UseAbility(Personage personage, int id)
        {
            // Первый аргумент - на кого применяем способность, второй - id способности, которую применяем.    
            // Находим в Dictionary необходимую способность.    
            // У текущего персонажа списываем стоимость применённой спобности.
            // Прибавляем действующие на него последствия способности, которые рассчитываются, то есть:

            // Ability ability = abilities[id];
            // AddResultOfAbility(ability.CalculateResult());
        }

        public void AddEffects(Effect effect)
        {
            effects.Add(effect);
        }

        public void AddAbility(Ability ability)
        {
        }

        public List<Ability> GetAvailableAbilities()
        {
            // Перебираем все имеющиеся способности и формируем список доступных.
            return null;
        }

   }
}
