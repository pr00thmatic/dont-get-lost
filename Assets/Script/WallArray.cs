using System.Collections;

//Array for the wall
public static class WallArray
{
    public static T[] WArray<T>(T[] _wallArray, int _seed)
    {
        System.Random rnd = new System.Random(_seed);

        for (int i = 0; i < _wallArray.Length - 1; i++)
        {
            int indx = rnd.Next(i, _wallArray.Length);
            T tmp = _wallArray[indx];
            _wallArray[indx] = _wallArray[i];
            _wallArray[i] = tmp;

        }
        return _wallArray;
    }
}
