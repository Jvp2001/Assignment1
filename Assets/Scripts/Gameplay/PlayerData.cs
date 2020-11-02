// © 2020 Joshua Petersen. All rights reserved.
/// <file>
/// <copyright> © 2020 Joshua Petersen. All rights reserved. </copyright>
/// </file>

using Assignment1;
using UnityEngine;

namespace Gameplay {
	/// <summary>
	/// I am using a delegate to update the UI due to it being better than using update. 
	/// </summary>
	/// <param name="newValue"> the newValue of <see cref="PlayerData.amountCollected"/>.</param>
	public delegate void AmountCollectedChanged(short newValue);

	public class PlayerData {
		private short amountCollected;

		public short AmountCollected {
			get => amountCollected;
			set {
				amountCollected = value;

				AmountCollectedChanged?.Invoke(amountCollected);
			}
		}

		/// <summary>
		/// This event is invoked when the <see cref="AmountCollected"/> property is changed. 
		/// </summary>
		public event AmountCollectedChanged AmountCollectedChanged;
	}
}