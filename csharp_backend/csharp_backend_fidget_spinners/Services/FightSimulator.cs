﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_backend_fidget_spinners.Models;
using csharp_backend_fidget_spinners.Services;
using csharp_backend_fidget_spinners.Services.CustomLogObj;
using csharp_backend_fidget_spinners.Services.ServiceInterfaces;

namespace csharp_backend_fidget_spinners.Services
{
    public class FightSimulator : IFightSimulator
    {
        private Character CurrentCharacter;
        private IEnemyGenerator EnemyGeneratorService;
        private Enemy Enemy;
        private Random RNG;
        private List<FightLog> FightLog;

        public FightSimulator()
        {
        }

        public List<FightLog> Fight(Character player, IEnemyGenerator enemyGenerator)
        {
            CurrentCharacter = player;
            EnemyGeneratorService = enemyGenerator;
            RNG = new Random();
            FightLog = new List<FightLog>();

            Enemy = EnemyGeneratorService.GenerateEnemy(CurrentCharacter);


            while(CurrentCharacter.MotivationLevel > 0 && Enemy.HP > 0)
            {
                int dealtDamage = CurrentCharacter.CalculateDamage(Enemy.BlockChance);
                Enemy.HP -= dealtDamage;

                LogRounds(CurrentCharacter.Name, dealtDamage);

                if (Enemy.HP > 0)
                {
                    dealtDamage = Enemy.CalculateEnemyDMG(CurrentCharacter.BlockChance);

                    CurrentCharacter.MotivationLevel -= dealtDamage;

                    LogRounds(Enemy.Name, dealtDamage);
                }
                
            }

            return FightLog;
        }

        private void LogRounds(string attackersName, int damageDealt)
        {
            FightLog.Add(new FightLog
            {
                DamageDealer = attackersName,
                DealtDMG = damageDealt,
                OurHealthPoint = CurrentCharacter.MotivationLevel,
                EnemyHealthPoint = Enemy.HP
            });
        }

        private bool ChanceGenerator(float chance)
        {
            bool isBlock = false;

            if (RNG.Next(0, 100) < chance)
            {
                isBlock = true;
            }

            return isBlock;
        }
    }
}