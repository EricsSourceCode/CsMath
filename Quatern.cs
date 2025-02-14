// Copyright Eric Chauvin 2018 - 2025.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



// There is a good book about the history of
// vectors and quaternions called A History
// of Vector Analysis, by Michael Crowe.
// It describes how modern vector analysis
// evolved, and how Hamilton's ideas about
// quaternions evolved.



using System;
// using System.Text;



// namespace



static class Quatern
{
// a + bi + cj + dk
// w + bx + cy + dz

public struct QuaternRec
{
public double x;
public double y;
public double z;
public double w;
}




internal static QuaternRec setOne()
{
QuaternRec result;
result.x = 0;
result.y = 0;
result.z = 0;
result.w = 1;
return result;
}



internal static QuaternRec setZero()
{
QuaternRec result;
result.x = 0;
result.y = 0;
result.z = 0;
result.w = 0;
return result;
}



internal static QuaternRec negate(
                           QuaternRec result )
{
result.x = -result.x;
result.y = -result.y;
result.z = -result.z;
result.w = -result.w;
return result;
}




internal static QuaternRec add(
          QuaternRec result, QuaternRec inQ )
{
result.x += inQ.x;
result.y += inQ.y;
result.z += inQ.z;
result.w += inQ.w;
return result;
}



internal static double normSquared(
                           QuaternRec inQ )
{
double ns = (inQ.x * inQ.x) +
            (inQ.y * inQ.y) +
            (inQ.z * inQ.z) +
            (inQ.w * inQ.w);

return ns;
}



internal static double norm( QuaternRec inQ )
{
double nSquared = normSquared( inQ );
return Math.Sqrt( nSquared );
}



internal static QuaternRec normalize(
                            QuaternRec inQ )
{
double length = norm( inQ );
if( length < 0.0000000000000001d )
  return setZero();

double inverse = 1.0d / length;

QuaternRec result;
result.x = inQ.x * inverse;
result.y = inQ.y * inverse;
result.z = inQ.z * inverse;
result.w = inQ.w * inverse;
return result;
}



internal static bool doubleIsAlmostEqual(
                       double a, double b,
                       double smallNumber )
{
// How small can this be?

if( a + smallNumber < b )
  return false;

if( a - smallNumber > b )
  return false;

return true;
}



internal static bool isAlmostEqual(
           QuaternRec left, QuaternRec right,
           double smallNumber )
{
if( !doubleIsAlmostEqual( left.x, right.x,
                                  smallNumber ))
  return false;

if( !doubleIsAlmostEqual( left.y, right.y,
                               smallNumber ))
  return false;

if( !doubleIsAlmostEqual( left.z, right.z,
                               smallNumber ))
  return false;

if( !doubleIsAlmostEqual( left.w, right.w,
                                 smallNumber ))
  return false;

return true;
}



internal static QuaternRec conjugate(
                              QuaternRec inQ )
{
QuaternRec result;
result.x = -inQ.x;
result.y = -inQ.y;
result.z = -inQ.z;
result.w = inQ.w;
return result;
}



internal static QuaternRec inverse(
                             QuaternRec inQ )
{
// QX = 1, so X is the multiplicative inverse
// of Q.  So X = 1 / Q, or Q^(-1).

double nSquared = normSquared( inQ );
if( nSquared < 0.0000000000001 )
  return setZero();

double inverseNS = 1.0d / nSquared;

// The negative parts are to make it the
// conjugate.  So the result is the conjugate
// divided by the norm squared.

QuaternRec result;
result.x = -inQ.x * inverseNS;
result.y = -inQ.y * inverseNS;
result.z = -inQ.z * inverseNS;
result.w = inQ.w * inverseNS;
return result;
}




// Partial Differential equations were
// around for about a couple of centuries
// before quaternions.
// The original meaining of the phrase
// Cross Product is with differentials
// like dxdy as opposed to dx squared.
// And it has to do with the Metric
// ds squared.
// (a + b + c)(a + b + c)
// aa + ab + ac + and so on...
// aa is not a cross product.
// ab  and ac are cross products.



internal static QuaternRec crossProduct(
                          QuaternRec left,
                          QuaternRec right )
{
// These are cross products:
// i x j = k
// j x k = i
// k x i = j

QuaternRec result;

// W is not used.
result.w = 0;

result.x = (left.y * right.z) -
           (left.z * right.y);

result.y = (left.z * right.x) -
           (left.x * right.z);

result.z = (left.x * right.y) -
           (left.y * right.x);

return result;
}




///////////////////////////
// Notes on Multiplication:

// It is a right-handed coordinate system.
// Positive Z values go toward the viewer.
// X goes to the right, Y goes up.

  // ij = k    ji = -k
  // jk = i    kj = -i
  // ki = j    ik = -j

  // xy = z    yx = -z
  // yz = x    zy = -x
  // zx = y    xz = -y

  //   i^2 = j^2 = k^2 = ijk = -1

  // With two regular complex numbers you do:
  //      (a + bi)(c + di) =
  //      ac + adi + bic + bidi

  // a1 is like a with subscript 1.

  // Multiply two quaternions:
  // Left times Right.
  // (a1x + b1y + c1z + w1)(a2x + b2y + c2z + w2)

  // Distributive Property:
  // a1x(a2x + b2y + c2z + w2) +
  // b1y(a2x + b2y + c2z + w2) +
  // c1z(a2x + b2y + c2z + w2) +
  // w1(a2x + b2y + c2z + w2)

  // Distributive Property again:
  // a1xa2x + a1xb2y + a1xc2z + a1xw2 +
  // b1ya2x + b1yb2y + b1yc2z + b1yw2 +
  // c1za2x + c1zb2y + c1zc2z + c1zw2 +
  // w1a2x + w1b2y + w1c2z + w1w2

  // a1a2xx + a1b2xy + a1c2xz + a1w2x +
  // b1a2yx + b1b2yy + b1c2yz + b1w2y +
  // c1a2zx + c1b2zy + c1c2zz + c1w2z +
  // w1a2x + w1b2y + w1c2z + w1w2

  // xy = z    yx = -z
  // yz = x    zy = -x
  // zx = y    xz = -y
  // a1a2-1 + a1b2z + a1c2-y + a1w2x +
  // b1a2-z + b1b2-1 + b1c2x + b1w2y +
  // c1a2y + c1b2-x + c1c2-1 + c1w2z +
  // w1a2x + w1b2y + w1c2z + w1w2

  // Rearrange it so the components are together:
  // a1w2x + w1a2x + b1c2x + c1b2-x +
  // a1c2-y + b1w2y + c1a2y + w1b2y +
  // a1b2z + b1a2-z + c1w2z + w1c2z +
  // -a1a2 + -b1b2 + -c1c2 + w1w2

  // a1w2x + w1a2x + b1c2x + -c1b2x +
  // -a1c2y + b1w2y + c1a2y + w1b2y +
  // a1b2z + -b1a2z + c1w2z + w1c2z +
  // -a1a2 + -b1b2 + -c1c2 + w1w2

  // x(a1w2 + w1a2 + b1c2 + -c1b2) +
  // y(-a1c2 + b1w2 + c1a2 + w1b2) +
  // z(a1b2 + -b1a2 + c1w2 + w1c2) +
  // The W parts:
  // -a1a2 + -b1b2 + -c1c2 + w1w2
  ///////////////////////////




internal static QuaternRec multiply(
                            QuaternRec L,
                            QuaternRec R )
{
// Result.X = a1w2 + w1a2 + b1c2 + -c1b2;
// Result.Y = -a1c2 + b1w2 + c1a2 + w1b2;
// Result.Z = a1b2 + -b1a2 + c1w2 + w1c2;
// Result.W = -a1a2 + -b1b2 + -c1c2 + w1w2;

QuaternRec result;

// The vector Cross Product part:
result.x =  (L.x * R.w) +  (L.w * R.x) +
                  (L.y * R.z) + (-L.z * R.y);
result.y = (-L.x * R.z) +  (L.y * R.w) +
                  (L.z * R.x) +  (L.w * R.y);
result.z =  (L.x * R.y) + (-L.y * R.x) +
                  (L.z * R.w) +  (L.w * R.z);

// Almost the same as the vector Dot Product.
result.w = (-L.x * R.x) + (-L.y * R.y) +
                 (-L.z * R.z) +  (L.w * R.w);
return result;
}



internal static QuaternRec
                    multiplyWithLeftVector3(
                            Vector3.Vect L,
                            QuaternRec R )
{
QuaternRec result;

// Result.X =  (L.x * R.W) +  (0 * R.X) +
//                (L.y * R.Z) + (-L.z * R.Y);
// Result.Y = (-L.x * R.Z) +  (L.y * R.W) +
//                (L.z * R.X) +  (0 * R.Y);
// Result.Z =  (L.x * R.Y) + (-L.y * R.X) +
//                (L.z * R.W) +  (0 * R.Z);
// Result.W = (-L.x * R.X) + (-L.y * R.Y) +
//                (-L.z * R.Z) +  (0 * R.W);

result.x =  (L.x * R.w) +  (L.y * R.z) +
                             (-L.z * R.y);
result.y = (-L.x * R.z) +  (L.y * R.w) +
                             (L.z * R.x);
result.z =  (L.x * R.y) + (-L.y * R.x) +
                             (L.z * R.w);
result.w = (-L.x * R.x) + (-L.y * R.y) +
                             (-L.z * R.z);
return result;
}



internal static Vector3.Vect
                    multiplyWithResultVector3(
                       QuaternRec L,
                       QuaternRec R )
{
Vector3.Vect result;
result.x =  (L.x * R.w) +  (L.w * R.x) +
                  (L.y * R.z) + (-L.z * R.y);
result.y = (-L.x * R.z) +  (L.y * R.w) +
                  (L.z * R.x) +  (L.w * R.y);
result.z =  (L.x * R.y) + (-L.y * R.x) +
                  (L.z * R.w) +  (L.w * R.z);

// It doesn't need this calculation:
// result.W = (-L.X * R.X) + (-L.Y * R.Y) +
//               (-L.Z * R.Z) +  (L.W * R.W);

return result;
}



internal static QuaternRec setAsRotation(
                          QuaternRec axis,
                          double angle )
{
// Make sure it's a unit quaternion.
axis.w = 0;
axis = normalize( axis );

// If Angle was Pi / 2 then this would be
// Pi / 4.
double halfAngle = angle * 0.5d;
double sineHalfAngle = Math.Sin( halfAngle );
double cosineHalfAngle = Math.Cos( halfAngle );

QuaternRec result;
result.x = axis.x * sineHalfAngle;
result.y = axis.y * sineHalfAngle;
result.z = axis.z * sineHalfAngle;
result.w = cosineHalfAngle;
return result;
}



internal static QuaternRec rotate(
                   QuaternRec rotationQ,
                   QuaternRec inverseRotationQ,
                   QuaternRec startPoint )
{
QuaternRec middlePoint = multiply(
               startPoint, inverseRotationQ );
QuaternRec result = multiply( rotationQ,
                              middlePoint );
return result;
}



internal static Vector3.Vect rotateVector3(
                 QuaternRec rotationQ,
                 QuaternRec inverseRotationQ,
                 Vector3.Vect startPoint )
{
// A quaternion rotation is clockwise
// around a vector if you are looking down
// the vector from the origin point.
// Like an archer with an arrow in the
// bow, you are sighting down the arrow.
// Compare this with representing a
// rotation or a moment of inertia, or
// a torque, by using a vector cross product
// in a right-handed coordinate system.
// It goes in the right direction like it
// should.  If the Z axis is pointing
// straight toward you then it is the opposite
// point of view from what an archer
// would see when he is sighting down an
// arrow in his bow.  That opposite point
// of view is a counter-clockwise rotation.

QuaternRec middlePoint =
                 multiplyWithLeftVector3(
                      startPoint,
                      inverseRotationQ );
Vector3.Vect result =
             multiplyWithResultVector3(
                      rotationQ, middlePoint );
return result;
}




internal static Vector3.Vect
                rotationWithSetupDegrees(
                      double angleDegrees,
                      QuaternRec axis,
                      Vector3.Vect inVector )
{
double angle = MathF.degreesToRadians(
                             angleDegrees );

QuaternRec rotationQ = setAsRotation(
                              axis, angle );
QuaternRec inverseRotationQ =
                       inverse( rotationQ );

Vector3.Vect resultPoint = rotateVector3(
                     rotationQ,
                     inverseRotationQ,
                     inVector );

return resultPoint;
}



} // Class
