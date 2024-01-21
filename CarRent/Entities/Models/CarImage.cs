namespace CarRent.Models;

public partial class CarImage
{
    public int CarImageId { get; set; }

    public int? CarId { get; set; }

    public byte[]? Image { get; set; }

    public virtual Car? Car { get; set; }
}
