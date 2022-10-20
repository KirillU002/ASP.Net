using System.ComponentModel.DataAnnotations;

namespace ASP.Net.Models
{
    public enum OrderStatus
    {
        Created,
        Processed,
        Delivering,
        Delivered,
        Canceled
    }
}