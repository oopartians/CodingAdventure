using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<T> where T : IComparable<T>
{
	List<T> _heap = new List<T>();

	// O(logN)
	public void Push(T data)
	{
		// Add New Data at End
		_heap.Add(data);

		int now = _heap.Count - 1;
        
		while (now > 0)
		{
			// Check
			int next = (now - 1) / 2;
			if (_heap[now].CompareTo(_heap[next]) < 0)
				break;

			// Swap
			T temp = _heap[now];
			_heap[now] = _heap[next];
			_heap[next] = temp;

			// Scan Next
			now = next;
		}
	}

	// O(logN)
	public T Pop()
	{
		// Save Return Data
		T ret = _heap[0];

		// Move Last Data to Root
		int lastIndex = _heap.Count - 1;
		_heap[0] = _heap[lastIndex];
		_heap.RemoveAt(lastIndex);
		lastIndex--;

		// Check Reverse
		int now = 0;
		while (true)
		{
			int left = 2 * now + 1;
			int right = 2 * now + 2;

			int next = now;
			// Move Left
			if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
				next = left;
			// Move Right
			if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
				next = right;

			// No Exist
			if (next == now)
				break;

			// Swap
			T temp = _heap[now];
			_heap[now] = _heap[next];
			_heap[next] = temp;

			// Scan Next
			now = next;
		}

		return ret;
	}

	public int Count { get { return _heap.Count; } }
}
