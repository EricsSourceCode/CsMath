// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class FloatVec
{
private MainData mData;
private float[] fArray;


private FloatVec()
{
}



internal FloatVec( MainData mainData )
{
mData = mainData;

try
{
fArray = new float[1];
}
catch( Exception ) //  Except )
  {
  string showS = "FloatVec: not" +
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
              "FloatVec.setSize() < 1" );
  }

try
{
if( howBig == fArray.Length )
  return;

fArray = new float[howBig];
}
catch( Exception ) // Except )
  {
  string showS = "FloatVec: not" +
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
             "FloatVec.getVal() range." );

return fArray[where];
}



internal void setVal( int where, float setTo )
{
RangeT.test( where, 0, fArray.Length - 1,
             "FloatVec.setVal() range." );

fArray[where] = setTo;
}



internal void copy( FloatVec toCopy )
{
int max = toCopy.getSize();

if( getSize() != max )
  setSize( max );

for( int count = 0; count < max; count++ )
  fArray[count] = toCopy.fArray[count];

}



internal void setFromString( string toSet )
{
if( toSet == null )
  return;

int max = toSet.Length;
int maxSize = getSize();
if( max > maxSize )
  max = maxSize;

for( int count = 0; count < max; count++ )
  {
  setVal( count, (float)toSet[count] );
  // mData.showStatus( "Vec: " + getVal( count ));
  }
}



} // Class
