
namespace GarageApplication
{
    internal interface IUIService
    {
        T GetValidEnumValue<T>(string prompt) where T : struct, Enum;
        int GetValidInteger(string prompt);
        int GetValidMenuChoice(int choices);
        string GetValidRegistrationNumber();
        string GetValidString(string prompt);
    }
}