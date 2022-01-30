using DG.Tweening;
using UnityEngine;

namespace CardSorting.Utils
{
    /// <summary>
    /// I moved on for Cubic Bezier solution.
    /// This is still here, since i'm curios. I'll try to run it with this function too. Sorry for the mess...
    /// </summary>
    public class Parabola
    {
       public static Vector3 SampleParabola ( Vector3 start, Vector3 end, float height, float t ) {
            float parabolicT = t * 2 - 1;
            if ( Mathf.Abs( start.y - end.y ) < 0.1f ) {
                //start and end are roughly level, pretend they are - simpler solution with less steps
                Vector3 travelDirection = end - start;
                Vector3 result = start + t * travelDirection;
                result.y += ( -parabolicT * parabolicT + 1 ) * height;
                return result;
            } else {
                //start and end are not level, gets more complicated
                Vector3 travelDirection = end - start;
                Vector3 levelDirecteion = end - new Vector3( start.x, end.y, start.z );
                Vector3 right = Vector3.Cross( travelDirection, levelDirecteion );
                Vector3 up = Vector3.Cross( right, travelDirection );
                if ( end.y > start.y ) up = -up;
                Vector3 result = start + t * travelDirection;
                result += ( ( -parabolicT * parabolicT + 1 ) * height ) * up.normalized;
                return result;
            }
            
        }
    }
}