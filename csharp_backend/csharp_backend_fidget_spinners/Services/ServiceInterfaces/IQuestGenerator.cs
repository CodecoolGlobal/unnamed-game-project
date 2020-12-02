﻿using csharp_backend_fidget_spinners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_backend_fidget_spinners.Services.ServiceInterfaces
{
    public interface IQuestGenerator
    {
        public Quest GenerateQuest(Character character, string questDifficulty);
        public int GenerateCoinReward(int charlevel, string difficulty, bool hasItemReward);
        public int GenerateXPReward(int charlevel, string difficulty, bool hasItemReward);
        public int GenerateTimeAndEnergyCost(string difficulty);

    }
}
