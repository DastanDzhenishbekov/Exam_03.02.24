using System;
using System.Collections.Generic;
using EXAM_4;
/// <summary>
/// Interface for strategies managing the characteristics of a crocodile.
/// </summary>
public interface ICharacteristicsStrategy
{
    /// <summary>
    /// Increase the characteristics of the crocodile.
    /// </summary>
    void IncreaseCharacteristics(Crocodile crocodile);

    /// <summary>
    /// Decrease the characteristics of the crocodile.
    /// </summary>
    void DecreaseCharacteristics(Crocodile crocodile);

    /// <summary>
    /// Apply a specific action to the crocodile.
    /// </summary>
    void ApplyAction(Crocodile crocodile, ActionType actionType);
}
