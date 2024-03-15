using Newtonsoft.Json;

namespace CPRO2211_Assignment_3_Trips_Log_Application.Models
{
    public class Packer
    {
        public string Pack(Trip tempData)
        {
            return JsonConvert.SerializeObject(tempData, Formatting.Indented);
        }
        public Trip Unpack(string json)
        {
            return JsonConvert.DeserializeObject<Trip>(json); ;
        }
    }
}
