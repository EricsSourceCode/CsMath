// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class Float32Matrix
{
private Float32Array[] fArray;


internal Float32Matrix()
{
try
{
fArray = new Float32Array[2];
}
catch( Exception ) //  Except )
  {
  string showS = "Float32Matrix: not" +
     " enough memory.";
     //   + Except.Message;

  throw new Exception( showS );
  }
}


void freeAll()
{
fArray = new Float32Array[2];
}


internal void setSize( int rows, int columns )
{
try
{
fArray = new Float32Array[rows];
}
catch( Exception ) // Except )
  {
  string showS = "Float32Matrix: not" +
     " enough memory.";

  throw new Exception( showS );
  }

for( int count = 0; count < columns; count++ )
  fArray[count].setSize( columns );

}



internal int getRows()
{
return fArray.Length;
}


/*
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

if( getSize() < max )
  setSize( max );

for( int count = 0; count < max; count++ )
  fArray[count] = toCopy.fArray[count];

}
*/



} // Class
