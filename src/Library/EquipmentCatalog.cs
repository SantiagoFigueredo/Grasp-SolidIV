using System.Collections.Generic;
using System.Linq;
using Full_GRASP_And_SOLID;

public class EquipmentCatalog : ICatalog<Equipment>
{
    private List<Equipment> equipmentList = new List<Equipment>();

    public void AddItem(Equipment equipment)
    {
        equipmentList.Add(equipment);
    }

    public Equipment GetItem(string description)
    {
        return equipmentList.FirstOrDefault(e => e.Description == description);
    }
}
