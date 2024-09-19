// Copyright Eric Chauvin 2024.




// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html



// See MatrixFlt.cs too.


using System;



// namespace



public class VectorArray
{
private MainData mData;
private VectorFlt[] fArray;
private int lastAppend = 0;



internal VectorArray( MainData mainData )
{
mData = mainData;

try
{
fArray = new VectorFlt[1];
fArray[0] = new VectorFlt( mData );

}
catch( Exception ) //  Except )
  {
  string showS = "VectorArray: not" +
     " enough memory.";
     //   + Except.Message;

  throw new Exception( showS );
  }
}



void freeAll()
{
fArray = new VectorFlt[1];
fArray[0] = new VectorFlt( mData );
}




internal void setSize( int rows, int columns )
{
if( (rows == getRows()) &&
    (columns == getColumns()))
  return;

if( rows < 1 )
  {
  throw new Exception(
          "VectorArray.setSize() rows." );
  }

if( columns < 1 )
  {
  throw new Exception(
             "VectorArray.setSize() col." );
  }

try
{
fArray = new VectorFlt[rows];
for( int count = 0; count < rows; count++ )
  fArray[count] = new VectorFlt( mData );

}
catch( Exception ) // Except )
  {
  string showS = "VectorArray: not" +
     " enough memory.";

  throw new Exception( showS );
  }

for( int count = 0; count < rows; count++ )
  fArray[count].setSize( columns );

}




internal void resizeRows( int newSize )
{
int oldSize = getRows();
int columns = getColumns();

if( newSize == oldSize )
  return;

if( newSize < 1 )
  {
  throw new Exception(
          "VectorArray.resizeRows() rows." );
  }

try
{
Array.Resize( ref fArray, newSize );

if( newSize > oldSize )
  {
  for( int count = oldSize; count < newSize;
                                    count++ )
    {
    // An array of structs would get initialized,
    // but not an array of objects.
    fArray[count] = new VectorFlt( mData );
    fArray[count].setSize( columns );
    }
  }
}
catch( Exception ) // Except )
  {
  throw new Exception(
       "Not enough memory for VectorArray." );

  }
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
             "VectorArray.getVal() range." );

// Column is checked in the FloatVec.
return fArray[row].getVal( col );
}



internal void setVal( int row, int col,
                      float setTo )
{
RangeT.test( row, 0, fArray.Length - 1,
             "VectorArray.setVal() range." );

fArray[row].setVal( col, setTo );
}




internal void copy( VectorArray toCopy )
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



internal void clearLastAppend()
{
lastAppend = 0;
}


internal int getLastAppend()
{
return lastAppend;
}




internal void appendFromString( string toSet )
{
if( toSet == null )
  {
  throw new Exception(
      "VArray appendFromString() null string." );
  }

// int col = getColumns();
// int max = toSet.Length;

int rows = getRows();
if( (lastAppend + 1 ) >= rows )
  resizeRows( rows + 1000 );

fArray[lastAppend].setFromString( toSet );
lastAppend++;
}




internal void appendOneVal( float toSet )
{
if( getColumns() < 2 )
  {
  throw new Exception(
      "VectorArray appendOneVal() columns." );
  }

int rows = getRows();
if( (lastAppend + 1 ) >= rows )
  resizeRows( rows + 1000 );

fArray[lastAppend].setVal( 1, toSet );
lastAppend++;
}



} // Class
