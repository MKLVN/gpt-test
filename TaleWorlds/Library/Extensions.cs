using System;
using System.Collections.Generic;
using System.Reflection;

namespace TaleWorlds.Library;

public static class Extensions
{
	public static List<Type> GetTypesSafe(this Assembly assembly, Func<Type, bool> func = null)
	{
		List<Type> list = new List<Type>();
		Type[] array;
		try
		{
			array = assembly.GetTypes();
		}
		catch (ReflectionTypeLoadException ex)
		{
			array = ex.Types;
			Debug.Print(ex.Message + " " + ex.GetType());
			foreach (object value in ex.Data.Values)
			{
				Debug.Print(value.ToString());
			}
		}
		catch (Exception ex2)
		{
			array = new Type[0];
			Debug.Print(ex2.Message);
		}
		foreach (Type type in array)
		{
			if (type != null && (func == null || func(type)))
			{
				list.Add(type);
			}
		}
		return list;
	}

	public static MBList<T> ToMBList<T>(this T[] source)
	{
		MBList<T> mBList = new MBList<T>(source.Length);
		mBList.AddRange(source);
		return mBList;
	}

	public static MBList<T> ToMBList<T>(this List<T> source)
	{
		MBList<T> mBList = new MBList<T>(source.Count);
		mBList.AddRange(source);
		return mBList;
	}

	public static MBList<T> ToMBList<T>(this IEnumerable<T> source)
	{
		if (source is T[] source2)
		{
			return source2.ToMBList();
		}
		if (source is List<T> source3)
		{
			return source3.ToMBList();
		}
		MBList<T> mBList = new MBList<T>();
		mBList.AddRange(source);
		return mBList;
	}

	public static void AppendList<T>(this List<T> list1, List<T> list2)
	{
		if (list1.Count + list2.Count > list1.Capacity)
		{
			list1.Capacity = list1.Count + list2.Count;
		}
		for (int i = 0; i < list2.Count; i++)
		{
			list1.Add(list2[i]);
		}
	}

	public static MBReadOnlyDictionary<TKey, TValue> GetReadOnlyDictionary<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
	{
		return new MBReadOnlyDictionary<TKey, TValue>(dictionary);
	}

	public static bool HasAnyFlag<T>(this T p1, T p2) where T : struct
	{
		return EnumHelper<T>.HasAnyFlag(p1, p2);
	}

	public static bool HasAllFlags<T>(this T p1, T p2) where T : struct
	{
		return EnumHelper<T>.HasAllFlags(p1, p2);
	}

	public static int GetDeterministicHashCode(this string text)
	{
		int num = 5381;
		for (int i = 0; i < text.Length; i++)
		{
			num = (num << 5) + num + text[i];
		}
		return num;
	}

	public static int IndexOfMin<TSource>(this IReadOnlyList<TSource> self, Func<TSource, int> func)
	{
		int num = int.MaxValue;
		int result = -1;
		for (int i = 0; i < self.Count; i++)
		{
			int num2 = func(self[i]);
			if (num2 < num)
			{
				num = num2;
				result = i;
			}
		}
		return result;
	}

	public static int IndexOfMin<TSource>(this MBReadOnlyList<TSource> self, Func<TSource, int> func)
	{
		int num = int.MaxValue;
		int result = -1;
		for (int i = 0; i < self.Count; i++)
		{
			int num2 = func(self[i]);
			if (num2 < num)
			{
				num = num2;
				result = i;
			}
		}
		return result;
	}

	public static int IndexOfMax<TSource>(this IReadOnlyList<TSource> self, Func<TSource, int> func)
	{
		int num = int.MinValue;
		int result = -1;
		for (int i = 0; i < self.Count; i++)
		{
			int num2 = func(self[i]);
			if (num2 > num)
			{
				num = num2;
				result = i;
			}
		}
		return result;
	}

	public static int IndexOfMax<TSource>(this MBReadOnlyList<TSource> self, Func<TSource, int> func)
	{
		int num = int.MinValue;
		int result = -1;
		for (int i = 0; i < self.Count; i++)
		{
			int num2 = func(self[i]);
			if (num2 > num)
			{
				num = num2;
				result = i;
			}
		}
		return result;
	}

	public static int IndexOf<TValue>(this TValue[] source, TValue item)
	{
		for (int i = 0; i < source.Length; i++)
		{
			if (source[i].Equals(item))
			{
				return i;
			}
		}
		return -1;
	}

	public static int FindIndex<TValue>(this IReadOnlyList<TValue> source, Func<TValue, bool> predicate)
	{
		for (int i = 0; i < source.Count; i++)
		{
			if (predicate(source[i]))
			{
				return i;
			}
		}
		return -1;
	}

	public static int FindIndex<TValue>(this MBReadOnlyList<TValue> source, Func<TValue, bool> predicate)
	{
		for (int i = 0; i < source.Count; i++)
		{
			if (predicate(source[i]))
			{
				return i;
			}
		}
		return -1;
	}

	public static int FindLastIndex<TValue>(this IReadOnlyList<TValue> source, Func<TValue, bool> predicate)
	{
		for (int num = source.Count - 1; num >= 0; num--)
		{
			if (predicate(source[num]))
			{
				return num;
			}
		}
		return -1;
	}

	public static int FindLastIndex<TValue>(this MBReadOnlyList<TValue> source, Func<TValue, bool> predicate)
	{
		for (int num = source.Count - 1; num >= 0; num--)
		{
			if (predicate(source[num]))
			{
				return num;
			}
		}
		return -1;
	}

	public static void Randomize<T>(this IList<T> array)
	{
		Random random = new Random();
		int num = array.Count;
		while (num > 1)
		{
			num--;
			int index = random.Next(0, num + 1);
			T value = array[index];
			array[index] = array[num];
			array[num] = value;
		}
	}
}
