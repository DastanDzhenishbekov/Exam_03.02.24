using System;
using System.Collections.Generic;
using EXAM_4;
public interface ICharacteristicsStrategy
{
    void IncreaseCharacteristics(Crocodile crocodile);
    void DecreaseCharacteristics(Crocodile crocodile);
    void ApplyAction(Crocodile crocodile, ActionType actionType);
}
