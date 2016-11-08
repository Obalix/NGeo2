using System;
using System.Collections.Generic;
using System.Text;

namespace NGeo.Shared.GeoNames.Model
{
	/// <summary>
	/// Enumeration for the GeoNames feature classes A,H,L,P,R,S,T,U,V
	/// </summary>
	public enum FeatureClass
	{
		/// <summary>
		/// Administrative Boundary Feature
		/// </summary>
		A = 'A',

		/// <summary>
		/// Hydrographic Features
		/// </summary>
		H = 'H',

		/// <summary>
		/// Area Features
		/// </summary>
		L = 'L',

		/// <summary>
		/// Populated Place Features
		/// </summary>
		P = 'P',

		/// <summary>
		/// Road / Railroad Features
		/// </summary>
		R = 'R',

		/// <summary>
		/// Spot Features
		/// </summary>
		S = 'S',

		/// <summary>
		/// Hypsographic Features
		/// </summary>
		T = 'T',

		/// <summary>
		/// Undersea Features
		/// </summary>
		U = 'U',

		/// <summary>
		/// Vegetation Features
		/// </summary>
		V = 'V',
	}
}
