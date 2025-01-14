﻿using System.Collections;
using Neuro.Cursor;

namespace Neuro.Minigames.Solvers;

[MinigameSolver(typeof(ShieldMinigame))]
public sealed class PrimeShieldsSolver : MinigameSolver<ShieldMinigame>
{
    protected override IEnumerator CompleteMinigame(ShieldMinigame minigame, NormalPlayerTask task)
    {
        for (int i = 0; i < minigame.Shields.Count; i++)
        {
            byte b = (byte)(1 << i);
            if ((minigame.shields & b) == 0)
            {
                yield return InGameCursor.Instance.CoMoveTo(minigame.Shields[i].transform.position);
                minigame.ToggleShield(i);
                yield return Sleep(0.1f);
            }
        }
    }
}

