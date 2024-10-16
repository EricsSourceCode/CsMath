// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class VectorFlt
{
private MainData mData;
private float[] fArray;


private VectorFlt()
{
}



internal VectorFlt( MainData mainData )
{
mData = mainData;

try
{
fArray = new float[1];
}
catch( Exception ) //  Except )
  {
  string showS = "VectorFlt: not" +
     " enough memory.";
     //   + Except.Message;

  throw new Exception( showS );
  }
}


void freeAll()
{
fArray = new float[1];
}



internal void setSize( int howBig )
{
if( howBig < 1 )
  {
  throw new Exception(
              "VectorFlt.setSize() < 1" );
  }

if( howBig == fArray.Length )
  return;

try
{
fArray = new float[howBig];
}
catch( Exception ) // Except )
  {
  string showS = "VectorFlt: not" +
     " enough memory.";

  throw new Exception( showS );
  }
}


internal int getSize()
{
return fArray.Length;
}



internal float getVal( int where )
{
RangeT.test( where, 0, fArray.Length - 1,
             "VectorFlt.getVal() range." );

return fArray[where];
}



internal void setVal( int where, float setTo )
{
RangeT.test( where, 0, fArray.Length - 1,
             "VectorFlt.setVal() range." );

fArray[where] = setTo;
}



internal void copy( VectorFlt toCopy )
{
int max = toCopy.getSize();

if( getSize() != max )
  setSize( max );

for( int count = 0; count < max; count++ )
  fArray[count] = toCopy.fArray[count];

}



internal void setFromString( string toSet )
{
clearZeros();

if( toSet == null )
  return;

int max = toSet.Length;
int maxSize = getSize();
if( max > maxSize )
  max = maxSize;

for( int count = 0; count < max; count++ )
  setVal( count, (float)toSet[count] );

}




internal void clearZeros()
{
int max = getSize();

for( int count = 0; count < max; count++ )
  fArray[count] = 0;

}



internal void resize( int newSize )
{
try
{
Array.Resize( ref fArray, newSize );
}
catch( Exception ) // Except )
  {
  throw new Exception(
       "Not enough memory for VectorFlt." );

  }
}



internal void add( VectorFlt toAdd )
{
int max = toAdd.getSize();

if( getSize() != max )
  throw new Exception( "VectorFlt add()" );

for( int count = 0; count < max; count++ )
  fArray[count] += toAdd.fArray[count];

}



internal float dotProd( VectorFlt y )
{
int max = y.getSize();

if( getSize() != max )
  {
  throw new Exception(
        "VectorFlt: dotProd() not same size." );
  }

float sum = 0;
for( int count = 0; count < max; count++ )
  sum += fArray[count] * y.fArray[count];

return sum;
}



internal float normSquared()
{
int max = getSize();

float sum = 0;
for( int count = 0; count < max; count++ )
  {
  float oneVal = fArray[count];
  sum += oneVal * oneVal;
  }

return sum;
}



internal float norm()
{
float nSquared = normSquared();
return (float)MathF.sqrt( nSquared );
}



internal void hadamard( VectorFlt x,
                        VectorFlt y )
{
int max = x.getSize();
if( max != y.getSize())
  throw new Exception( "VectorFlt hadamard()" );

// If it needs to change size.
setSize( max );

for( int count = 0; count < max; count++ )
  {
  fArray[count] = x.fArray[count] *
                  y.fArray[count];
  }
}



internal void subtract( VectorFlt x,
                        VectorFlt y )
{
// x - y
int max = x.getSize();
if( max != y.getSize())
  throw new Exception( "VectorFlt subtract()" );

// If it needs to change size.
setSize( max );

for( int count = 0; count < max; count++ )
  {
  fArray[count] = x.fArray[count] -
                  y.fArray[count];
  }
}



} // Class
