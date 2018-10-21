//----------------------------------------------------------------------------------------
//	Copyright © 2006 - 2018 Tangible Software Solutions, Inc.
//	This class can be used by anyone provided that the copyright notice remains intact.
//
//	This class provides the ability to replicate the behavior of the C/C++ functions for 
//	generating random numbers, using the .NET Framework System.Random class.
//	'rand' converts to the parameterless overload of NextNumber
//	'random' converts to the single-parameter overload of NextNumber
//	'randomize' converts to the parameterless overload of Seed
//	'srand' converts to the single-parameter overload of Seed
//----------------------------------------------------------------------------------------
[System.Obsolete("Use standard C# features")]
internal static class RandomNumbers
{
    private static System.Random r = new System.Random();

    public static byte NextByte () => (byte)r.Next(0, 255);

	public static int NextNumber() => r.Next();

	public static int NextNumber(int ceiling) => r.Next(ceiling);
    
	public static void Seed(int seed)
	{
		r = new System.Random(seed);
	}
}