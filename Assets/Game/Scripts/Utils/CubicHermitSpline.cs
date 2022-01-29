using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace CardSorting.Utils
{
    public class CubicHermitSpline
    {
        public Vector2 start;
        public Vector2 end;
        public float startTangent;
        public float endTangent;

        public CubicHermitSpline(Vector2 start, Vector2 end, float startTangent, float endTangent)
        {
            this.start = start;
            this.end = end;
            this.startTangent = startTangent;
            this.endTangent = endTangent;
        }

        /// <summary>
        /// Source: https://en.wikipedia.org/wiki/Cubic_Hermite_spline#Catmull%E2%80%93Rom_spline
        /// </summary>
        public Vector2 Solve(float t)
        {
            float a = 2 * t * t * t - 3 * t * t + 1;
            float b = t * t * t - 2 * t * t + t;
            float c = -2 * t * t * t + 3 * t * t;
            float d = t * t * t - t * t;

            float x = a * start.x + b * startTangent + c * end.x + endTangent * d;
            float y = a * start.y + b * startTangent + c * end.y + endTangent * d;
            return new Vector2(x, y);
        }

        public float SolveTangent(float t)
        {
            float a = 6 * t * t - 6 * t;
            float b = 3 * t * t - 4 * t + 1;
            float c = -6 * t * t + 6 * t;
            float d = 3 * t * t - 2 * t;

            float x = a * start.x + b * startTangent + c * end.x + endTangent * d;
            float y = a * start.y + b * startTangent + c * end.y + endTangent * d;

            return Mathf.Atan(y / x) * Mathf.Rad2Deg;
        }
    }
}