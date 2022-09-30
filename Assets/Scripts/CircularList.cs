using System.Collections;
using System.Collections.Generic;
public class CircularList<T> : List<T>
{
    // https://stackoverflow.com/a/68684000/9930211
    private int _currentIndex = 0;
    public int CurrentIndex
    {
        get
        {
            if (_currentIndex > Count - 1) { _currentIndex = 0; }
            if (_currentIndex < 0) { _currentIndex = Count - 1; }
            return _currentIndex;
        }
        set => _currentIndex = value;
    }

    public int NextIndex
    {
        get
        {
            if (_currentIndex == Count - 1) return 0;
            return _currentIndex + 1;
        }
    }

    public int PreviousIndex
    {
        get
        {
            if (_currentIndex == 0) return Count - 1;
            return _currentIndex - 1;
        }
    }

    public T Next => this[NextIndex];

    public T Previous => this[PreviousIndex];

    public T MoveNext
    {
        get { _currentIndex++; return this[CurrentIndex]; }
    }

    public T MovePrevious
    {
        get { _currentIndex--; return this[CurrentIndex]; }
    }

    public T Current => this[CurrentIndex];


}
