// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



// Basic Math Functions.


using System;





public static class MathF
{

internal static double sqrt( double x )
{
return Math.Sqrt( x );
}


internal static double log( double x )
{
// Log to the base e.
return Math.Log( x );
}



internal static double exp( double x )
{
// This is e to the x.
return Math.Exp( x );
}




internal static int strToInt( string inS,
                              int def )
{
int result = 0;

try
{
result = Int32.Parse( inS );
}
catch( Exception )
  {
  return def; // default
  }

return result;
}


internal static bool almostEqual(
                         double a, double b )
{
// How small can this be?
double smallNumber = 0.000000000001;

if( a + smallNumber < b )
  return false;

if( a - smallNumber > b )
  return false;

return true;
}


internal static double
                   degreesMinutesToRadians(
                           double Degrees,
                           double Minutes,
                           double Seconds )
{
double Deg = Degrees + (Minutes / 60.0d) +
                   (Seconds / (60.0d * 60.0d));
// Math.PI
// 3.14159265358979323846
double RadConstant = (2.0d *
             3.14159265358979323846d) / 360.0d;
return Deg * RadConstant;
}



internal static double degreesToRadians(
                             double degrees )
{
double RadConstant = (2.0d *
              3.14159265358979323846d) / 360.0d;
return degrees * RadConstant;
}




internal static double radiansToDegrees(
                                double radians )
{
double RadConstant = 360.0d /
           (2.0d * 3.14159265358979323846d);
return radians * RadConstant;
}



internal static double rightAscensionToRadians(
                             double hours,
                             double minutes,
                             double seconds )
{
// Hours, minutes and seconds, with 24
// hours being 360 degrees.

double totalHours = hours +
                (minutes / 60.0d) + (seconds /
                (60.0d * 60.0d));
double degrees = totalHours * (360.0d / 24.0d);
// If totalHours was 24 then it would be
// 24 * (360 / 24) = 360
// If totalHours was 12 then it would be
// 12 * (360 / 24) = 180

return degreesToRadians( degrees );
}





} // Class
