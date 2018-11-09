using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayTree.Framework
{
    public class GameTime
    {
        public static float GameSpeed { get; set; }
        public static float DeltaTime { get { return GameSpeed * Time.deltaTime; } }
        public static float FixedDeltaTime { get { return GameSpeed * Time.deltaTime; } }


    }
}
