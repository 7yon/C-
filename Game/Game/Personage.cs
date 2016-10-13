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

        private Dictionary<int, Ability> abilities;
        private List<ResultOfAbility> personageChanges;

        Personage()
        {
        }

        public int GetCurrentHealth()
        {
            int currentHelth = health;
            //перебираем все действующие к персонажу результаты способностей (personageChanges)
            //берём только differenceOfHealth из каждого ResultOfAbility
            //рассчитываем currentHelth
            return currentHelth;
        }

        public int GetCurrentSpeed()
        {
            int currentSpeed = speedMovement;
            //перебираем все действующие к персонажу результаты способностей (personageChanges)
            //берём только differenceOfSpeed из каждого ResultOfAbility
            //рассчитываем currentSpeed
            return currentSpeed;
        }

        public int GetCurrentMana()
        {
            int currentMana = mana;
            //перебираем все действующие к персонажу результаты способностей (personageChanges)
            //берём только differenceOfMana из каждого ResultOfAbility
            //рассчитываем currentMana
            return currentMana;
        }

        public void UseAbility(Personage personage, int id)
        {
            //первый аргумент - на кого применяем способность, второй - id способности, которую применяем    
            //находим в Dictionary необходимую способность    
            //у текущего персонажа списываем стоимость применённой спобности
            //и прибавляем действующие на него последствия способности, которые рассчитываются, то есть

            //Ability ability = abilities[id];
            //AddResultOfAbility(ability.CalculateResult());
        }

        public void AddAbility(Ability ability)
        {
        }

        public void AddResultOfAbility(ResultOfAbility resultOfAbility)
        {
        }

        public List<Ability> GetAvailableAbilities()
        {
            //перебираем все имеющиеся способности и формируем список доступных
            return null;
        }

   }
}
