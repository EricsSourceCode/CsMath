// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



// Basic Math Functions.


using System;




// This class is mainly for things from
// the System.Math class.



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



} // Class
