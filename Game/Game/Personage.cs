using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Personage
    {
        private int hitPoints;
        private int health;
        private int speedMovement;
        private int speedRegenerationOfMana;
        private int mana;

        private Dictionary<int, Ability> abilities = new Dictionary<int, Ability>();
        private List<Effect> effects = new List<Effect>();

        Personage()
        {
        }

        public int GetCurrentHealth()
        {
            int currentHelth = health;
            // Просматриваем все способности, ищем необходимую и узнаем её id.
            // Просматриваем все эффекты и если id эффекта == id необходимой способности, то суммируем.

            return currentHelth;
        }

        public int GetCurrentSpeed()
        {
            int currentSpeed = speedMovement;

            // См. Предыдущий комментарий

            return currentSpeed;
        }

        public int GetCurrentMana()
        {
            int currentMana = mana;

            // См. Предыдущий комментарий

            return currentMana;
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
