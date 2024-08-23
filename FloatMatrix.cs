// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;



// namespace



public class FloatMatrix
{
private FloatVec[] fArray;


internal FloatMatrix()
{
try
{
fArray = new FloatVec[2];
}
catch( Exception ) //  Except )
  {
  string showS = "FloatMatrix: not" +
     " enough memory.";
     //   + Except.Message;

  throw new Exception( showS );
  }
}


void freeAll()
{
fArray = new FloatVec[2];
}


internal void setSize( int rows, int columns )
{
if( (rows == getRows()) &&
    (columns == getColumns()))
  return;

if( rows < 1 )
  {
  throw new Exception( 
          "FloatMatrix.setSize() rows." );
  }

if( columns < 1 )
  {
  throw new Exception( 
             "FloatMatrix.setSize() col." );
  }

try
{
fArray = new FloatVec[rows];
}
catch( Exception ) // Except )
  {
  string showS = "FloatMatrix: not" +
     " enough memory.";

  throw new Exception( showS );
  }

for( int count = 0; count < rows; count++ )
  fArray[count].setSize( columns );

}



internal int getRows()
{
return fArray.Length;
}



internal int getColumns()
{
return fArray[0].getSize();
}



internal float getVal( int row, int col )
{
RangeT.test( row, 0, fArray.Length - 1,
             "FloatMatrix.getVal() range." );

// Column is checked in the FloatVec.
return fArray[row].getVal( col );
}



internal void setVal( int row, int col,
                      float setTo )
{
RangeT.test( row, 0, fArray.Length - 1,
             "Float32Array.setVal() range." );

fArray[row].setVal( col, setTo );
}




internal void copy( FloatMatrix toCopy )
{
int rows = toCopy.getRows();
int columns = toCopy.getColumns();

setSize( rows, columns );

for( int row = 0; row < rows; row++ )
  {
  for( int col = 0; col < columns; col++ )
    {
    float val = toCopy.getVal( row, col );
    fArray[row].setVal( col, val );
    }
  }
}




} // Class
