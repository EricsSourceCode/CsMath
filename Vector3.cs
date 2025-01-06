// Copyright Eric Chauvin 2018 - 2025.




// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



// See the Quatern.cs file for notes.



using System;



// namespace



public static class Vector3
{


public struct Vect
{
public double x;
public double y;
public double z;
}



internal static Vect makeZero()
{
Vect result;
result.x = 0;
result.y = 0;
result.z = 0;

return result;
}


internal static Vect negate( Vect inV )
{
inV.x = -inV.x;
inV.y = -inV.y;
inV.z = -inV.z;

return inV;
}



internal static Vect add( Vect left,
                          Vect right )
{
Vect result;
result.x = left.x + right.x;
result.y = left.y + right.y;
result.z = left.z + right.z;
return result;
}



internal static Vect subtract( Vect left,
                               Vect right )
{
Vect result;

result.x = left.x - right.x;
result.y = left.y - right.y;
result.z = left.z - right.z;
return result;
}



internal static double normSquared( Vect inV )
{
double ns = (inV.x * inV.x) +
            (inV.y * inV.y) +
            (inV.z * inV.z);

return ns;
}



internal static double norm( Vect inV )
{
double nSquared = normSquared( inV );
return Math.Sqrt( nSquared );
}



internal static Vect normalize( Vect inV )
{
double length = (inV.x * inV.x) +
                (inV.y * inV.y) +
                (inV.z * inV.z);

length = Math.Sqrt( length );

const double smallNumber =
                      0.000000000000000001d;
if( length < smallNumber )
  return makeZero();

double inverse = 1.0d / length;

Vect result;
result.x = inV.x * inverse;
result.y = inV.y * inverse;
result.z = inV.z * inverse;
return result;
}



internal static Vect multiplyWithScalar(
                  Vect inV, double scalar )
{
Vect result;
result.x = inV.x * scalar;
result.y = inV.y * scalar;
result.z = inV.z * scalar;
return result;
}



internal static double dotProduct(
                      Vect left, Vect right )
{
double dot = (left.x * right.x) +
             (left.y * right.y) +
             (left.z * right.z);

return dot;
}


/*
Make the third side of the triangle?
Is that what this is?

internal static Vect makePerpendicular(
                            Vect A, Vect B )
{
// A and B are assumed to be already normalized.
// Make a vector that is perpendicular to A,
// pointing toward B.

double dot = dotProduct( A, B );
Vect cosineLengthVec = A;
cosineLengthVec = multiplyWithScalar(
                     cosineLengthVec, dot );

// CosineLengthVec now points in the same
// direction as A, but it's shorter.

// cosineLengthVec + result = B
// result = B - cosineLengthVec

Vect result = B;
result = subtract( result, cosineLengthVec );
result = normalize( result );

// They should be orthogonal to each other.
// double TestDot = DotProduct( A, Result );
// if( Math.Abs( TestDot ) > 0.00000001 )
   // throw( new Exception(
   //         "TestDot should be zero." ));

return result;
}
*/


internal static Vect crossProduct(
                              Vect left,
                              Vect right )
{
// i x j = k
// j x k = i
// k x i = j

Vect result;

result.x = (left.y * right.z) -
           (left.z * right.y);

result.y = (left.z * right.x) -
           (left.x * right.z);

result.z = (left.x * right.y) -
           (left.y * right.x);

return result;
}



} // Class
