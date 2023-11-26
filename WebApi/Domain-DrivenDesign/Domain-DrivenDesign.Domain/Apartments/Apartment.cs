using Domain_DrivenDesign.Domain.Abstractions;

namespace Domain_DrivenDesign.Domain.Apartments;
public sealed class Apartment : Entity //Entity
{//factory design pattern
    public Apartment(
        Guid id, 
        Name name, 
        Description description, 
        Money price, 
        Address address, 
        Money cleaningFee, 
        DateTime? lastBooked): base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Address = address;
        CleaningFee = cleaningFee;
        LastBooked = lastBooked;
    }

    public Name Name { get; private set; } //pirimitive // ilket tipler
    public Description Description { get; private set; }
    public Money Price { get; private set; }
    public Address Address { get; private set; } //güçlü entity yapıları
    public Money CleaningFee { get; private set; }
    public DateTime? LastBooked { get; private set; }
}
