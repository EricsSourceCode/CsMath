// Copyright Eric Chauvin 2018 - 2024.




// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



// See the Quatern.cs file for notes.



using System;


// namespace



static class Vector3
{


public struct Vect
{
public double X;
public double Y;
public double Z;
}



internal static Vect makeZero()
{
Vect result;
result.X = 0;
result.Y = 0;
result.Z = 0;

return result;
}


internal static Vect negate( Vect inV )
{
inV.X = -inV.X;
inV.Y = -inV.Y;
inV.Z = -inV.Z;

return inV;
}



internal static Vect add( Vect left,
                          Vect right )
{
Vect result;
result.X = left.X + right.X;
result.Y = left.Y + right.Y;
result.Z = left.Z + right.Z;
return result;
}



internal static Vect subtract( Vect left,
                               Vect right )
{
Vect result;

result.X = left.X - right.X;
result.Y = left.Y - right.Y;
result.Z = left.Z - right.Z;
return result;
}



internal static double normSquared( Vect inV )
{
double ns = (inV.X * inV.X) +
            (inV.Y * inV.Y) +
            (inV.Z * inV.Z);

return ns;
}



internal static double norm( Vect inV )
{
double nSquared = normSquared( inV );
return Math.Sqrt( nSquared );
}



internal static Vect normalize( Vect inV )
{
double length = (inV.X * inV.X) +
                (inV.Y * inV.Y) +
                (inV.Z * inV.Z);

length = Math.Sqrt( length );

const double smallNumber =
                      0.000000000000000001d;
if( length < smallNumber )
  return makeZero();

double inverse = 1.0d / length;

Vect result;
result.X = inV.X * inverse;
result.Y = inV.Y * inverse;
result.Z = inV.Z * inverse;
return result;
}



internal static Vect multiplyWithScalar(
                  Vect inV, double scalar )
{
Vect result;
result.X = inV.X * scalar;
result.Y = inV.Y * scalar;
result.Z = inV.Z * scalar;
return result;
}



internal static double dotProduct(
                      Vect left, Vect right )
{
double dot = (left.X * right.X) +
             (left.Y * right.Y) +
             (left.Z * right.Z);

return dot;
}



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



internal static Vect crossProduct(
                              Vect left,
                              Vect right )
{
// i x j = k
// j x k = i
// k x i = j

Vect result;

result.X = (left.Y * right.Z) -
           (left.Z * right.Y);

result.Y = (left.Z * right.X) -
           (left.X * right.Z);

result.Z = (left.X * right.Y) -
           (left.Y * right.X);

return result;
}



} // Class
