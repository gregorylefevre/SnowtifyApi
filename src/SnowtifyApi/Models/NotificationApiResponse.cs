namespace SnowtifyApi.Models
{
    public class NotificationApiResponse<T>
    {
        public string Status { get; set; }

        public string ExecTime { get; set; }

        public T Body { get; set; }
    }
}