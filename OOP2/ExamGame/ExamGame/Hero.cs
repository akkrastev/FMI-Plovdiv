using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamGame
{
    public abstract class Hero
    {
        private const int MIN_ATTACK = 80;
        private const int MAX_ATTACK = 120;
        private const int MIN_DEFENCE = 80;
        private const int MAX_DEFENCE = 120;

        public int attackPoints { get; set; }
        public int defencePoints { get; set; }
        public int healthPoints { get; set; }
        public string Name { get; set; }

        public event EventHandler<AttackStartArgs> AttackStart;
        public event EventHandler<AttackEndArgs> AttackEnd;
        public event EventHandler<DefenceStartArgs> DefenceStart;
        public event EventHandler<DefenceEndArgs> DefenceEnd;
        public event EventHandler<DeadHeroArgs> DeadHero;

        public Hero(string name, int attack, int defence, int health)
        {
            this.Name = name;
            this.attackPoints = attack;
            this.defencePoints = defence;
            this.healthPoints = health;
        }

        private void MakeAttack(int rawDamage)
        {
            if (AttackStart != null)
            {
                new EventHandler<AttackStartArgs>(AttackStart)
                    (
                    this, new AttackStartArgs
                    {
                        rawDmg = rawDamage,
                        Attacker = this


                    });
            }
        }

        private void EndAttack(int rawDamage)
        {
            if(AttackEnd != null)
            {
                new EventHandler<AttackEndArgs>(AttackEnd)
                    (this, new AttackEndArgs
                    {
                        Attacker = this
                    });
            }

        }
        private void StartDefence (int AttackDmg)
        {
            if(DefenceStart != null)
            {
                new EventHandler<DefenceStartArgs>(DefenceStart)(
                    this, new DefenceStartArgs
                    {
                      attackDmg = AttackDmg,
                      Defender = this
                    }
                    );
            }
        }

        private void EndDefence (int AttackDmg)
        {
            if (DefenceEnd != null)
            {
                new EventHandler<DefenceEndArgs>(DefenceEnd)

                    (this, new DefenceEndArgs
                    {
                        attackDmg = AttackDmg,
                        Defender = this,
                        healthPoints = healthPoints
                    });
            }
        }
        private void Die()
        {
            if(DeadHero != null){

                new EventHandler<DeadHeroArgs>(DeadHero)(
                    this, new DeadHeroArgs {
                        DeadHero = this
                    });
            }
        }

        public virtual int Attack(int percent)
        {
            int rawDmg = percent * attackPoints / 100;
            MakeAttack(rawDmg);

            return rawDmg;
           
        }

        public virtual int Defence(int rawDmg, int percentAfterDefence)
        {
            int damageAfterDefence = percentAfterDefence * defencePoints / 100;
            int attackDamage = rawDmg - damageAfterDefence;

            healthPoints -= attackDamage;

            if(healthPoints < 0)
            {
                healthPoints = 0;
            }

            StartDefence(attackDamage);

            if(healthPoints == 0)
            {
                Die();
            }
            return attackDamage;
        }

        public virtual int DefaultAttack()
        {
            int percent = new Random().Next(MIN_ATTACK, MAX_ATTACK + 1);

            return Attack(percent);
        }

        public virtual int DefaultDefence (int rawDmg)
        {
            int percentAfterDefence = new Random().Next(MIN_DEFENCE, MAX_DEFENCE + 1);
            return Defence(rawDmg, percentAfterDefence);
        }

        public virtual int HigherDamageAttack (int  HIGHER_DAMAGE_CHANCE, int HIGHER_DAMAGE_PERCENT)
        {
            if (new Random().Next(1, 101) <= HIGHER_DAMAGE_CHANCE)
            {
                return Attack(HIGHER_DAMAGE_PERCENT);
            }
            else
            {
                return DefaultAttack();
            }
        }
        public virtual int HigherDefenceChance(int rawDmg, int HIGHER_DEFENCE_CHANCE, int HIGHER_DEFENCE_PERCENT)
        {
            if (new Random().Next(1, 101) <= HIGHER_DEFENCE_CHANCE)
            {
                return Defence(rawDmg, HIGHER_DEFENCE_PERCENT);
            }
            else
            {
                return DefaultDefence(rawDmg);
            }
        }
        public virtual void DefenceBlockAttack(int rawDamage, int BLOCK_ATTACK_CHANCE)
        {
            if (new Random().Next(1, 101) <= BLOCK_ATTACK_CHANCE)
            {
                StartDefence(0);
                return;
            }

            DefaultDefence(rawDamage);
        }

        abstract public int Attack();
        abstract public void DefendAgainst(int rawDamage);


    }
        

}

