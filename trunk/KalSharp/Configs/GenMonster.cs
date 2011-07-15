﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs.ConfigPropertyTypes;

namespace KalSharp.Configs
{
    public class GenMonster : ConfigType
    {
        /// <summary>
        /// Monster Index that will be spawned.
        /// </summary>
        public int Index;
        /// <summary>
        /// Map to spawn monster on.
        /// </summary>
        public int Map;
        /// <summary>
        /// Unique Index.
        /// </summary>
        public int Area;
        /// <summary>
        /// Maximum spawn count.
        /// </summary>
        public int Max;
        /// <summary>
        /// Delay between spawns.
        /// </summary>
        public int Cycle;
        /// <summary>
        /// Monster spawn location.
        /// </summary>
        public GenMonsterRect Rect;
    }
}
