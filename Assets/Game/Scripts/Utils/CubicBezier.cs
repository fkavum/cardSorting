using UnityEngine;

namespace CardSorting.Utils
{
    public class CubicBezier
    {
        public Vector2 start;
        public Vector2 end;
        public Vector2 controlPoint;

        public CubicBezier(Vector2 start, Vector2 end, Vector2 controlPoint)
        {
            this.start = start;
            this.end = end;
            this.controlPoint = controlPoint;
        }

        /// <summary>
        /// Source: https://stackoverflow.com/questions/48602141/drawing-a-parabolic-arc-between-two-points-based-on-a-known-projectile-angle
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Vector2 Solve(float t)
        {
            float a = (1 - t) * (1 - t);
            float b = 2 * (1 - t) * t;
            float c = t * t;

            float x = a * start.x + b * controlPoint.x + c * end.x;
            float y = a * start.y + b * controlPoint.y + c * end.y;
            return new Vector2(x, y);
        }

        public float SolveTangent(float t)
        {
            // float a = 2*(1-t) -1;
            // float b = 2 - 4*t;
            // float c = 2*t;

            float a = 2 * t - 2;
            float b = 2 * (1 - 2 * t);
            float c = 2 * t;

            float x = a * start.x + b * controlPoint.x + c * end.x;
            float y = a * start.y + b * controlPoint.y + c * end.y;
            return Mathf.Atan(y / x) * Mathf.Rad2Deg;
        }
    }
}