namespace HomeAPI.Models
{
    public class SensorInfoModel
    {
        public int SensorID { get; set; }
        public int MoistureLevel { get; set; }
        public required string Plant { get; set; }
    }
}
