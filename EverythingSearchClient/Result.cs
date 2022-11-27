﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverythingSearchClient
{

	/// <summary>
	/// Read-only results of a search run
	/// </summary>
	public class Result
	{

		/// <summary>
		/// Descriptive type flags for items
		/// </summary>
		[Flags]
		public enum ItemFlags
		{
			/// <summary>
			/// Item is a normal file
			/// </summary>
			None = 0,

			/// <summary>
			/// Item is a folder
			/// </summary>
			Folder = 1,

			/// <summary>
			/// Item is a drive or root
			/// </summary>
			Drive = 2,

			/// <summary>
			/// Something strange
			/// </summary>
			Unknown = 0x80

		}

		/// <summary>
		/// Description of one item
		/// </summary>
		public class Item
		{

			/// <summary>
			/// Gets the type flags
			/// </summary>
			public ItemFlags Flags { get; protected set; } = ItemFlags.None;

			/// <summary>
			/// Gets the name of the item, not including any path segment
			/// </summary>
			public string Name { get; protected set; } = string.Empty;

			/// <summary>
			/// Gets the path to the item, without the item's name
			/// </summary>
			public string Path { get; protected set; } = string.Empty;

		}

		/// <summary>
		/// Gets the total number of items found in the search run
		/// </summary>
		public UInt32 TotalItems { get; protected set; } = 0;

		/// <summary>
		/// Gets the number of items returned in this object
		/// </summary>
		public UInt32 NumItems { get => (UInt32)Items.Length; }

		/// <summary>
		/// Gets the offset of the results array of this object
		/// inside the total results list of the search run.
		/// </summary>
		public UInt32 Offset { get; protected set; } = 0;

		/// <summary>
		/// Gets the array of found items
		/// </summary>
		public Item[] Items {get; protected set; } = Array.Empty<Item>();

	}

}
