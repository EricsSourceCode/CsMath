// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class Float32Array
{
private float[] fArray;


internal Float32Array()
{
try
{
fArray = new float[2];
}
catch( Exception ) //  Except )
  {
  string showS = "Float32Array: not" +
     " enough memory.";
     //   + Except.Message;

  throw new Exception( showS );
  }
}


void freeAll()
{
fArray = new float[2];
}



internal void setSize( int howBig )
{
if( howBig < 1 )
  {
  throw new Exception(
              "Float32Array.setSize() < 1" );
  }

try
{
if( howBig == fArray.Length )
  return;

fArray = new float[howBig];
}
catch( Exception ) // Except )
  {
  string showS = "Float32Array: not" +
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
             "Float32Array.getVal() range." );

return fArray[where];
}



internal void setVal( int where, float setTo )
{
RangeT.test( where, 0, fArray.Length - 1,
             "Float32Array.setVal() range." );

fArray[where] = setTo;
}



internal void copy( Float32Array toCopy )
{
int max = toCopy.getSize();

if( getSize() != max )
  setSize( max );

for( int count = 0; count < max; count++ )
  fArray[count] = toCopy.fArray[count];

}




} // Class
